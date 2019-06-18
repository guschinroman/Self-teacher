using System;
using System.Collections.Generic;
using System.Linq;
using ServiceTeacher.Service.Domain.Services.Translators;

namespace ServiceTeacher.Service.Infrastructure.Services.Translator
{
    public abstract class Translator<TSource, TDest> : ITranslator<TSource, TDest>
        where TSource : class, new()
        where TDest: class, new()
    {

        public Translator()
        {
        }

        public  TDest Translate(TSource source)
        {
            return Map(source);
        }

        protected abstract TDest Map(TSource source);

        public object Translate(object source)
        {
            return Translate((TSource)source);
        }

        public IEnumerable<TDest> Translate(IEnumerable<TSource> source)
        {
            return source.Select(Translate).ToArray();
        }

        public void Update(TSource source, TDest destination)
        {
            Map(source, destination);
        }

        protected abstract void Map(TSource source, TDest destination);

        protected string EnumToString<T>(T value)
            where T : struct
        {
            return value.ToString();
        }

        protected T IntToEnum<T>(int value)
            where T : struct
        {
            var res = (T)(object)value;
            return res;
        }

        protected string DateToString(DateTime date)
        {
            return date.ToString("G");
        }
        

    }
}
