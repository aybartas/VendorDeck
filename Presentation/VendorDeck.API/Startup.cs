using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using VendorDeck.API.Middlewares;
using VendorDeck.Application;
using VendorDeck.Application.Validators;
using VendorDeck.Infrastructure;
using VendorDeck.Persistence.IOC;

namespace VendorDeck.API
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
            services
                .AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<AddProductValidator>())
                .AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.Converters.Add(new OrderStatusConverter());
                    }); 

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPIv5", Version = "v1" });
            });
            services.AddPersistenceServices(Configuration);
            services.AddApplicationServices();
            services.AddInfrastructureServices(Configuration);
            services.AddMemoryCache();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtConfig:SecretKey"])),
                    ValidateIssuer = true,
                    ValidIssuer = Configuration["JwtConfig:ValidIssuer"],
                    ValidateAudience = true,
                    ValidAudience = Configuration["JwtConfig:ValidAudience"],
                };
            });

            services.AddAuthorization();
            services.ConfigureApplicationCookie(opt =>
            {
                //opt.AccessDeniedPath = "/Account/Login";
                //opt.LogoutPath = "Account/Login";
            });
            services.AddCors();

            //services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            string[] allowedOrigins = Configuration.GetSection("AllowedOrigins").Get<string[]>();

            app.UseMiddleware<ExceptionMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPIv5 v1"));
            }

            app.UseExceptionHandler("/Error");
            //app.UseHttpsRedirection();


            app.UseCors(option =>
            {
                option.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
                .WithOrigins(allowedOrigins);
            });

            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
