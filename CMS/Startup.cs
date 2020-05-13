using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CMS.Context;
using CMS.Infrastructure;
using CMS.Infrastructure.Settings;
using CMS.Models.Db.Account;
using CMS.Services;
using CMS.Services.interfaces;
using Google.Apis.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CMS
{
    public class Startup
    {
        // Wstrzykiwanie pliku konfiguracyjnego do naszej aplikacji
        public IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment env)
        {
            var config = new ConfigurationBuilder();

            if (env.IsDevelopment())
            {
                // Jeżeli jesteśmy w trybie produkcyjnym to zaciągnij dane konfiguracyjne z secrets.json
                config.AddJsonFile("secrets.json");
            }
            if (env.IsProduction())
            {
                // Je¿eli jesteśmy w trybie produkcyjnym to zaciągnij dane ze zmniennych środowiskowych
                config.AddEnvironmentVariables("CMSOPEN_");
            }

            Configuration = config.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Łączenie z bazą danych
            services.AddDbContext<CMSContext>(builder =>
            {
                // Dodajemy dostawcę do obsługi MySql'a i przekazujemy connection string pobrany z pliku konfiguracyjnego z naszej aplikacji
                builder.UseMySql(Configuration.GetConnectionString("DefaultConnection"));
            });

            // Wstrzykujemy zależności o identifykacji użytkowników
            services.AddIdentity<User, IdentityRole>(options =>
            {
                // Opcje dotyczące hasła
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 2;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

            }).AddEntityFrameworkStores<CMSContext>();

            // Dodajemy obsługę silnika razor oraz controllerów
            services.AddRazorPages();
            services.AddControllersWithViews();
            // Dodajemy obsługę dodawania opcji w konfiguracji
            services.AddOptions();

            // Tutaj dodajemy zależności do wstrzykiwania
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<ICloudService, CloudinaryService>();
            services.AddScoped<IMediaService, MediaService>();
            services.AddScoped<ITaxonomyService, TaxonomyService>();
            services.AddScoped<IPageService, PageService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IAppearanceService, AppearanceService>();
            services.AddScoped<ISettingsService, SettingsService>();
            services.AddScoped<ISeoService, SeoService>();
            services.AddScoped<INotificationService, SlackService>();
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<IEmailService, EmailService>();

            // Konfiguracja platformy cloudinary do przechowywania zdjęć w chmurze
            services.Configure<CloudinarySettings>(Configuration.GetSection("CloudinarySettings"));
            // Konfiguracja slacka
            services.Configure<SlackSettings>(Configuration.GetSection("SlackSettings"));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var cultureInfo = new CultureInfo("pl-PL");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if (env.IsProduction())
            {
                // app.UseHttpsRedirection();
                app.UseExceptionHandler("/blad");
            }

            // dodajemy obsługę plików statycznych z ~/wwwroot
            app.UseStaticFiles();

            // włączamy używanie autoryzacji i autentykacji z .NET Core Identity
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // ustawiamy routing na domyślny Model - View - Controller
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
