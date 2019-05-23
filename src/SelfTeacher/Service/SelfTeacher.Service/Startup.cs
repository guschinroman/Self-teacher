using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SelfTeacher.Service.Helpers.DataContext;
using ServiceTeacher.Service.Infrastructure.Helpers;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ServiceTeacher.Service.Domain.Services;
using ServiceTeacher.Service.Infrastructure.Services;
using ServiceTeacher.Service.Domain.Helpers;
using SelfTeacher.Service.CommandFabric;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using ServiceTeacher.Service.Infrastructure.Services.EmailService;
using ServiceTeacher.Service.Domain.Services.EmailService;
using SelfTeacher.Service.Translator;
using ServiceTeacher.Service.Domain.Services.Translators;
using ServiceTeacher.Service.Domain.Entities;
using ServiceTeacher.Service.Infrastructure.Services.AuthServices;
using ServiceTeacher.Service.Domain.Services.AuthSerivce;
using ServiceTeacher.Service.Infrastructure.Services.Translator.Vk;

namespace SelfTeacher.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var translatorFactory = new ServiceTranslatorFactory();
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddCors();
            services.AddDbContext<DataContext>(x => x.UseSqlServer("Server=PC-23\\SQLEXPRESS12;Database=SelfTeacher.dev;Trusted_Connection=True;"));

            services.AddAutoMapper();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var appSettingSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingSection);

            var appSettings = appSettingSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x => {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAppSettings>(t => appSettings);
            services.AddScoped<UserCommandFabric, UserCommandFabric>();
            services.AddScoped<AccountCommandFabric, AccountCommandFabric>();
            services.AddScoped<IClientEmailSender, ClientEmailSender>();
            services.AddScoped<IEmailTemplateNameService, EmailTemplateNameService>();
            services.AddSingleton<IEmailService, EmailService>();
            services.AddScoped<ITraslatorInitializator, ServiceTranslatorFactory>((service) =>
            {
                Mapper.Initialize(cfg =>
                {
                    translatorFactory.Initialize(cfg);
                });
                return translatorFactory;
            });
            services.AddScoped<IVkAuthService, VkAuthService>();
            services.AddScoped(typeof(ITranslator<VkUserDto, User>),
                (conf) =>
                {
                    return new VkUserDtoToUserTranslator(translatorFactory.Configuration, translatorFactory.Mapper);
                }
            );

            ServiceLocator.SetLocatorProvider(services.BuildServiceProvider());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
