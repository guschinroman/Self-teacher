using ServiceTeacher.Service.Domain.Entities;
using ServiceTeacher.Service.Infrastructure.Services.AuthServices;

namespace ServiceTeacher.Service.Infrastructure.Services.Translator.Vk
{
    public class VkUserDtoToUserTranslator : Translator<VkUserDto, User>
    {
        public VkUserDtoToUserTranslator()
            : base()
        {
        }

        protected override User Map(VkUserDto source)
        {
            var user = new User();
            user.Firstname = source.first_name;
            user.Lastname = source.last_name;
            user.Username = $"{source.last_name} {source.first_name}";
            user.Vk_id = source.id;

            return user;
        }

        protected override void Map(VkUserDto source, User destination)
        {
            destination.Firstname = source.first_name;
            destination.Lastname = source.last_name;
            destination.Username = source.last_name + source.first_name;
            destination.Vk_id = source.id;
        }
    }
}
