using EvenementsAPI.BusinessLogic;
using EvenementsAPI.Data;
using EvenementsAPI.Filters;
using EvenementsAPI.Models;
using EvenementsAPI.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EvenementsAPI
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
            services.AddScoped<IEvenementRepository, EvenementRepository>();
            services.AddScoped<IVilleRepository, VilleRepository>();
            services.AddScoped<IRepository<Categorie>, Repository<Categorie>>();
            services.AddScoped<IRepository<Participation>, Repository<Participation>>();
            services.AddScoped<IRepository<CategorieEvenement>, Repository<CategorieEvenement>>();
            services.AddScoped<IEvenementsBL, EvenementsBL>();
            services.AddScoped<IParticipationsBL,ParticipationsBL>();
            services.AddScoped<IVillesBL,VillesBL>();
            services.AddScoped<ICategoriesBL, CategoriesBL>();

            services.AddDbContext<EvenementsContext>(options =>
                options
                .UseNpgsql(Configuration.GetConnectionString("EvenementsContext")));

            services.AddControllers(o => { o.AllowEmptyInputInBodyModelBinding = true; o.Filters.Add<HtppResponseExceptionFilter>(); })
                .ConfigureApiBehaviorOptions(o => o.SuppressModelStateInvalidFilter = true)
                .AddJsonOptions(o => o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            services.AddAuthentication("Bearer").AddJwtBearer(options =>
            {
                options.Authority = "https://localhost:5001";
                options.Audience = "Web2Api";
                options.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true
                };
            });

            services.AddAuthorization(pb =>
                {
                    pb.AddPolicy("requireScope", o => o.RequireAssertion(o => o.User.HasClaim(c => c.Type.Equals("scope") && c.Value.Equals("web2ApiScope"))));
                    pb.DefaultPolicy = pb.GetPolicy("requireScope");
                }
            );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EvenementsAPI", Version = "v1" });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                //AddSwagerGen options
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri("https://localhost:5001/connect/authorize"),
                            TokenUrl = new Uri("https://localhost:5001/connect/token"),
                            Scopes = new Dictionary<string, string>
                             {
                                {"web2ApiScope", "Demo API - scope web2Api"}
                             }
                        }
                    }
                });
                c.OperationFilter<AuthorizeCheckOperationFilter>();

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EvenementsAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireAuthorization();
            });
        }
    }
}
