using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ServiceTeacher.Service.Domain.Services.Translators;

namespace ServiceTeacher.Service.Infrastructure.Services.Translator
{
    public class Translator<TSource, TDest> : ITranslator<TSource, TDest>
        where TSource : class
        where TDest: class
    {
        protected IMapper _mapper { get; private set; }
        protected IMapperConfigurationExpression _configuration { get; private set; }

        public Translator(IMapperConfigurationExpression configuration, IMapper mapper)
        {
            _mapper = mapper;
            _configuration = configuration;
            var mapping = _configuration.CreateMap<TSource, TDest>();
            ConfigTranslator(mapping);
        }

        public TDest Translate(TSource source)
        {
            return _mapper.Map<TDest>(source);
        }

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
            _mapper.Map(source, destination);
        }

        public void Update(object source, object destination)
        {
            _mapper.Map((TSource)source, (TDest)destination);
        }

        protected virtual void ConfigTranslator(IMappingExpression<TSource, TDest> cfg)
        {
        }

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
