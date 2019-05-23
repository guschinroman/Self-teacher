using AutoMapper;
using ServiceTeacher.Service.Domain.Entities;
using ServiceTeacher.Service.Infrastructure.Services.AuthServices;

namespace ServiceTeacher.Service.Infrastructure.Services.Translator.Vk
{
    public class VkUserDtoToUserTranslator : Translator<VkUserDto, User>
    {
        public VkUserDtoToUserTranslator(IMapperConfigurationExpression configuration, IMapper mapper)
            : base(configuration, mapper)
        {
        }

        protected override void ConfigTranslator(IMappingExpression<VkUserDto, User> cfg)
        {
            base.ConfigTranslator(cfg);

            cfg.ForMember(x => x.Email, o => o.MapFrom(t => t.email))
                .ForMember(x => x.Firstname, o => o.MapFrom(t => t.first_name))
                .ForMember(x => x.Lastname, o => o.MapFrom(t => t.last_name));
        }
    }
}
