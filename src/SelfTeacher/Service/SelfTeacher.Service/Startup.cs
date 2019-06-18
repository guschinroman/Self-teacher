using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceTeacher.Service.Infrastructure.Helpers;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ServiceTeacher.Service.Domain.Services;
using ServiceTeacher.Service.Infrastructure.Services;
using ServiceTeacher.Service.Domain.Helpers;
using SelfTeacher.Service.CommandFabric;
using Microsoft.AspNetCore.Http;
using ServiceTeacher.Service.Infrastructure.Services.EmailService;
using ServiceTeacher.Service.Domain.Services.EmailService;
using SelfTeacher.Service.Translator;
using ServiceTeacher.Service.Domain.Services.Translators;
using ServiceTeacher.Service.Domain.Entities;
using ServiceTeacher.Service.Infrastructure.Services.AuthServices;
using ServiceTeacher.Service.Domain.Services.AuthSerivce;
using ServiceTeacher.Service.Infrastructure.Services.Translator.Vk;
using SelfTeacher.Service.Helpers.DataAccess;
using SelfTeacher.Service.Services;

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
            services.AddDbContext<DataContext>(x => x.UseSqlServer(Configuration["connectionString:TeacherDB"]));
            
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

            var iocServiceInit = new IocServiceInitialization(services, appSettings, translatorFactory);
            iocServiceInit.Initialize();
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
