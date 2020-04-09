using AutoMapper;
using Hangfire;
using Hangfire.Dashboard;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using AspNet.Security.OAuth.Vkontakte;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OAuth;
using Newtonsoft.Json.Linq;
using VkNet;
using Vshope.Application.Auth;
using Vshope.Application.Auth.Abstr;
using Vshope.Application.Common;
using Vshope.Application.Common.Abstr;
using Vshope.Application.Main;
using Vshope.Application.Main.Abstr;
using Vshope.Application.Util;
using Vshope.Application.Util.Abstr;
using Vshope.Common;
using Vshope.Db.Common;
using Vshope.Model.Model.Auth;
using Vshope.Model.Model.Common;
using Vshope.Model.Model.Dict;
using Vshope.Model.Model.Main;
using Vshope.Web.Helpers;
using Vshope.Web.Helpers.Jobs;
using Vshope.Web.Validation;

namespace Vshope.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            ConstantsApp.InitializeByConfig(configuration);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ContextApp>(options =>
                options.UseMySql(connection));
            services.AddOptions();

            services.AddAuthentication(options => { options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme; })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = ConstantsApp.AUTH_ISSUER,
                        ValidateAudience = true,
                        ValidAudience = ConstantsApp.AUTH_AUDIENCE,
                        ValidateLifetime = true,
                        IssuerSigningKey = ConstantsApp.GetAuthJwtSymmetricKeyBytes(),
                        ValidateIssuerSigningKey = true
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                            {
                                context.Response.Headers.Add("x-token-expired", "true");
                            }

                            return Task.CompletedTask;
                        }
                    };
                });
                /*.AddVkontakte(
                    options =>
                    {
                        options.ApiVersion = Configuration["VkApi:Version"];
                        options.ClientId = Configuration["VkApi:AppId"];
                        options.ClientSecret = Configuration["VkApi:ClientSecret"];

                        options.Scope.Clear();
                        options.Scope.Add("offline");
                        options.Scope.Add("market");
                        options.CallbackPath = Path.Combine("/api/user/loginVkCallback");
                    });*/

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConfiguration(Configuration.GetSection("Logging"));
                loggingBuilder.AddConsole();
                loggingBuilder.AddDebug();
            });

            services.AddCors();


            //services.AddHangfire(config =>
            //    config.UseSqlServerStorage(Configuration.GetConnectionString("DefaultConnection")));


            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.DateFormatString = "yyyy-MM-ddTHH:mm:sszzz";
                });


            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(100, 0);
                o.ApiVersionReader = new UrlSegmentApiVersionReader();
            });
            services.AddVersionedApiExplorer(options => options.GroupNameFormat = "'v'VVV");


            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen();
            services.AddSwaggerToPostman();

            services.AddAutoMapper(
                typeof(CommonProfile),
                typeof(AuthProfile),
                typeof(DictProfile),
                typeof(MainProfile)
            );

            services.AddScoped<ContextApp, ContextApp>();
            services.AddScoped<IScopeService, ScopeService>();
            services.AddScoped<IDictService, DictService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IVkService, VkService>();
            services.AddScoped<IAvitoXmlService, AvitoXmlService>();
            services.AddScoped<IWebRequestService, WebRequestService>();
            services.AddScoped<ICompanyService, CompanyService>();

            services.AddScoped<JobDeleteTempFiles, JobDeleteTempFiles>();

            services.AddScoped<UserLoginDTOValidator, UserLoginDTOValidator>();
            services.AddScoped<CompanyDTOValidator, CompanyDTOValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider provider, ILoggerFactory loggerFactory)
        {
            

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
                .WithExposedHeaders("x-token-expired", "content-disposition"));

            DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
            defaultFilesOptions.DefaultFileNames.Clear();
            defaultFilesOptions.DefaultFileNames.Add(Configuration["AppSettings:FrontAppIndexFile"]);
            app.UseDefaultFiles(defaultFilesOptions);
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMiddleware(typeof(ExceptionHandleMiddleware));

            //loggerFactory.AddAzureWebAppDiagnostics();

            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint(
                            $"/swagger/{description.GroupName}/swagger.json",
                            description.GroupName.ToUpperInvariant());
                    }
                });
            app.UseSwaggerToPostman();

            //var hangfireSection = Configuration.GetSection("Hangfire");
            //app.UseHangfireDashboard("/hangfire", new DashboardOptions
            //{
            //    IsReadOnlyFunc = (DashboardContext context) => bool.Parse(hangfireSection["Readonly"])
            //});
            //app.UseHangfireServer();


            //app.UseIpRateLimiting();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
            app.MapWhen(x => !x.Request.Path.Value.StartsWith("/api")
                          && !x.Request.Path.Value.StartsWith("/public"), builder =>
                          {
                              builder.UseMvc(routes =>
                              {
                                  routes.MapSpaFallbackRoute(
                                      "spa-fallback",
                                      new { controller = "Home", action = "Index" });
                              });
                          });


            InitializeDatabase(app);
            //InitializeJobs(app);
        }

        private void InitializeDatabase(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                try
                {
                    scope.ServiceProvider.GetRequiredService<ContextApp>().Database.Migrate();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
               
            }
        }

        private void InitializeJobs(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                try
                {
                    //RecurringJob.AddOrUpdate<JobDeleteTempFiles>(nameof(JobDeleteTempFiles),
                    //    job => job.Run(JobCancellationToken.Null),
                    //    Cron.Weekly);
                }
                catch (Exception e)
                {
                    var exeption = e;
                }
            }
        }

        public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
        {
            readonly IApiVersionDescriptionProvider provider;

            public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) =>
                this.provider = provider;

            public void Configure(SwaggerGenOptions options)
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(
                        description.GroupName,
                        new Info()
                        {
                            Title = $"API {description.ApiVersion}",
                            Version = description.ApiVersion.ToString(),
                        });
                }

                options.DescribeAllParametersInCamelCase();
                options.IncludeXmlComments(Path.Combine(PlatformServices.Default.Application.ApplicationBasePath,
                    "Vshope.Web.xml"));
            }
        }
    }
}
