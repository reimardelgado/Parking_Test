using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Microsoft.AspNetCore.CookiePolicy;
using ParkingLots.API.Configurations.AutofacConfig;
using ParkingLots.Domain.Interfaces.Repositories;
using ParkingLots.Infrastructure;
using ParkingLots.Infrastructure.Middlewares;
using ParkingLots.Infrastructure.Repositories;
using ParkingLots.Infrastructure.Security;

namespace ParkingLots.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(
                    Environment.GetEnvironmentVariable("PARKINGLOTS_DB_CONNECTION")
                    ?? Configuration.GetConnectionString("DbParkingLots"))
            );

            //JWT config
            services.AddOptions<JwtAuthenticationSettings>()
                .Bind(Configuration.GetSection("JWT"));

            services.AddHttpContextAccessor();
            services.AddControllers(opt => opt.Filters.Add(typeof(JwtAuthorizationActionFilter)));

            //services.AddCors();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API Parkin Lots",
                    Version = "v1.0"
                });
                c.SchemaFilter<CustomSchemaFilters>();
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Name = Configuration["Jwt:TokenName"],
                            Type = SecuritySchemeType.ApiKey,
                            In = ParameterLocation.Header,
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            services.AddAuthentication("JWT")
                .AddScheme<JwtAuthenticationSchemaOptions, JwtAuthenticationHandler>("JWT", null)
                .AddJwtBearer(options =>
                {
                    var jwtKey = Encoding.ASCII.GetBytes(Configuration["Jwt:Key"]);
                    var securityKey = new SymmetricSecurityKey(jwtKey);

                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ClockSkew = TimeSpan.Zero,
                        TokenDecryptionKey = securityKey,
                        IssuerSigningKey = new SymmetricSecurityKey(jwtKey),
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Parking Lots V1"); });
            }

            var origenAllowedList = new List<string>();
            Configuration.GetSection("OriginalAllowedList").Bind(origenAllowedList);

            app.UseCors(b =>
            {
                b.AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithExposedHeaders(Configuration["Jwt:TokenName"])
                    .SetIsOriginAllowed((string origin) => origenAllowedList.Contains(origin))
                    .AllowCredentials();
            });

            app.UseHsts();
            //  app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCookiePolicy(new CookiePolicyOptions { HttpOnly = HttpOnlyPolicy.Always });
            app.UseAuthentication();
            app.UseAuthorization();

            ConfigureMiddlewares(app);

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        private void ConfigureMiddlewares(IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new MediatorModule());
            builder.RegisterModule(new RepositoryModule());
            builder.RegisterModule(new ServicesModule());
        }
    }
}