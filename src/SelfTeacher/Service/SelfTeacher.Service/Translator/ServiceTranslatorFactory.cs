using AutoMapper;
using ServiceTeacher.Service.Infrastructure.Translators;

namespace SelfTeacher.Service.Translator
{
    public class ServiceTranslatorFactory: CommonTranslatorInitializator
    {
        public override void Initialize(IMapperConfigurationExpression cfg)
        {
            base.Initialize(cfg);

        }
    }
}
