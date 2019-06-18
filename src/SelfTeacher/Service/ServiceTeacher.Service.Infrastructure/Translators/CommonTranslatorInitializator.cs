using ServiceTeacher.Service.Domain.Entities;
using ServiceTeacher.Service.Domain.Services;
using ServiceTeacher.Service.Infrastructure.Services.AuthServices;
using ServiceTeacher.Service.Domain.Services.Translators;
using System.Collections.Generic;
using System.Linq;
using System;
using ServiceTeacher.Service.Infrastructure.Services;
using ServiceTeacher.Service.Infrastructure.Services.Translator.Vk;

namespace ServiceTeacher.Service.Infrastructure.Translators
{
    public class CommonTranslatorInitializator: ITraslatorInitializator
    {
        private readonly List<TranslatorInfo> _translators;

        public CommonTranslatorInitializator()
        {
            _translators = new List<TranslatorInfo>();
        }

        public ITranslator<TSource, TDestination> GetTranslator<TSource, TDestination>()
        {
            return (ITranslator<TSource, TDestination>)_translators
                .First(x => x.SourceType == typeof(TSource) &&
                            x.DestinationType == typeof(TDestination))
                .Translator;
        }

        public virtual void Initialize()
        {
            RegisterTranslator(CreateTranslator<VkUserDto, User, VkUserDtoToUserTranslator>());
        }

        public void RegisterTranslator<TSource, TDestination>(ITranslator<TSource, TDestination> translator)
        {
            _translators.Add(new TranslatorInfo
            {
                SourceType = typeof(TSource),
                DestinationType = typeof(TDestination),
                Translator = translator
            });
        }

        protected ITranslator<TSource, TDesc> CreateTranslator<TSource, TDesc, TTranslator>()
        {
            try
            {
                return ServiceLocator.Current.GetInstance<ITranslator<TSource, TDesc>>();
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Cannot create translator of type: {0}. Check constructor parameters constraint!", typeof(TTranslator)), e);
            }
        }
    }
}
