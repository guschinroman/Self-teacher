${
  using Typewriter.Extensions.Types;

	class Dependency
	{
		public string Class { get; }
		public string Source { get; }

		public Func<Class, bool> Condition { get; }

		public Dependency(string clazz, string source)
		{
			Class = clazz;
			Source = source;
		}

		public Dependency(string clazz, string source, Func<Class, bool> condition)
		{
			Class = clazz;
			Source = source;
			Condition = condition;
		}
	}

	static Dictionary<string, List<Dependency>> _dependencies;
	static List<string> _ignorableClasses;

	Template(Settings settings)
	{
		settings.IncludeProject("ServiceTeacher.Service.Infrastructure");

		_ignorableClasses = new List<string>();
		_dependencies = new Dictionary<string, List<Dependency>>();

		InitializeDependencies();
		InitializeIgnorableClasses();
	}

	string GenerateClass(Class clazz)
	{
		if(clazz.Name.EndsWith("StoreFileDto"))
			return "{}";

		var clazzString = string.Empty;
		if (clazz.BaseClass != null && clazz.BaseClass.Name.Equals("ListItemDto"))
			clazzString +=  " implements ITableItemDto {" + Environment.NewLine;
		else if (clazz.BaseClass != null && clazz.Name.Equals("ListDto")) {
			clazzString +=  "<T> extends Array<any> {" + Environment.NewLine;
        } else
			clazzString += " { " + Environment.NewLine;

		var props = GetPropertiesRecursively(clazz);
		foreach(var prop in props)
		{
			var type = prop.Type.ToString();
			if(type.ToLower().Equals("tdto[]"))
				type = "Array<ITableDTO>";
			if(type.ToLower().Equals("t"))
				type = "any";
			clazzString += "\tpublic " + prop.Name +  "?: " + type + " = undefined;" + Environment.NewLine;
		}

		clazzString += "}" + Environment.NewLine;

		return clazzString;
	}

	string GetTypeNameClean(Type type)
	{
		var name = type.Name.TrimEnd('[', ']');

		if(name.ToLower().Equals("string"))
			return "String";
		else if(name.ToLower().Equals("number"))
			return "Number";
		else if(name.ToLower().Equals("t"))
			return "any";
		else if(name.ToLower().Equals("tdto[]"))
			return "Array<ITableDTO>";
		return name;
	}

	void InitializeIgnorableClasses()
	{
		_ignorableClasses.Add("BakedItemDto");
	}

	void InitializeDependencies()
	{
        _dependencies.Add("UserDto", new List<Dependency>
      {        
        new Dependency("EUserAccountState", "./EUserAccountState")
      }); 
      _dependencies.Add("AuthenticateDto", new List<Dependency>
      {        
        new Dependency("EUserAccountState", "./EUserAccountState")
      }); 
	}

	string GenerateImports(Class clazz)
	{
    var imports = string.Empty;
		if (clazz.Name.EndsWith("EditoStateDto"))
			return imports;

    List<Dependency> allClassesDependencies;
    if(!_dependencies.TryGetValue("*", out allClassesDependencies))
      allClassesDependencies = new List<Dependency>();
						
		List<Dependency> classDependencies;
		if(!_dependencies.TryGetValue(clazz.Name, out classDependencies))
			classDependencies = new List<Dependency>();

		imports += string.Join(
      Environment.NewLine,
      Enumerable
        .Concat(classDependencies, allClassesDependencies)
				.Where(x => x.Condition == null || x.Condition(clazz))
				.Select(x => $"import {{ {x.Class} }} from '{x.Source}';"));
								
		return imports;
	}

	ICollection<Property> GetPropertiesRecursively(Class clazz)
	{
		var pops = new List<Property>();
		pops.AddRange(clazz.Properties);

		if(clazz.BaseClass != null)
			pops.AddRange(GetPropertiesRecursively(clazz.BaseClass));

		 return pops;
	}
}$Classes(e => !_ignorableClasses.Contains(e.Name) && e.Name.EndsWith("Dto"))[$GenerateImports


export class $Name $GenerateClass ]
