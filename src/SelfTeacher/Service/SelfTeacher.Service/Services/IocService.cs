using Microsoft.Extensions.DependencyInjection;
using SelfTeacher.Service.CommandFabric;
using SelfTeacher.Service.Infrastructure.Dtos;
using SelfTeacher.Service.Translator;
using SelfTeacher.Service.Translator.User;
using ServiceTeacher.Service.Domain.Entities;
using ServiceTeacher.Service.Domain.Helpers;
using ServiceTeacher.Service.Domain.Services;
using ServiceTeacher.Service.Domain.Services.AuthSerivce;
using ServiceTeacher.Service.Domain.Services.EmailService;
using ServiceTeacher.Service.Domain.Services.Translators;
using ServiceTeacher.Service.Infrastructure.Services;
using ServiceTeacher.Service.Infrastructure.Services.AuthServices;
using ServiceTeacher.Service.Infrastructure.Services.EmailService;
using ServiceTeacher.Service.Infrastructure.Services.Translator.Vk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfTeacher.Service.Services
{
    public class IocServiceInitialization
    {
        private readonly IServiceCollection _services;
        private readonly IAppSettings _appSettings;
        private readonly ServiceTranslatorFactory _translatorFactory;

        public IocServiceInitialization(IServiceCollection services,
            IAppSettings appSettings,
            ServiceTranslatorFactory translatorFactory)
        {
            _services = services;
            _appSettings = appSettings;
            _translatorFactory = translatorFactory;
        }

        public void Initialize()
        {

            InitServices();
            InitTranslators();
        }

        private void InitTranslators()
        {
            _services.AddSingleton(typeof(ITranslator<VkUserDto, User>),
                (conf) =>
                {
                    return new VkUserDtoToUserTranslator();
                }
            );

            _services.AddSingleton(typeof(ITranslator<User, UserDto>),
                (conf) =>
                {
                    return new UserToUserDtoTranslator();
                }
            );
            _services.AddSingleton(typeof(ITranslator<UserDto, User>),
                (conf) =>
                {
                    return new UserDtoToUserTranslator();
                }
            );

            ServiceLocator.SetLocatorProvider(_services.BuildServiceProvider());
            _translatorFactory.Initialize();
        }

        private void InitServices()
        {
            _services.AddScoped<IUserService, UserService>();
            _services.AddScoped<IAppSettings>(t => _appSettings);
            _services.AddScoped<UserCommandFabric, UserCommandFabric>();
            _services.AddScoped<AccountCommandFabric, AccountCommandFabric>();
            _services.AddScoped<IClientEmailSender, ClientEmailSender>();
            _services.AddScoped<IEmailTemplateNameService, EmailTemplateNameService>();
            _services.AddSingleton<IEmailService, EmailService>();
            _services.AddScoped<IVkAuthService, VkAuthService>();
        }
    }
}
