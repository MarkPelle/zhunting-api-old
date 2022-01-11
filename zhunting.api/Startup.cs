using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using zhunting.DataAccess;
using Microsoft.EntityFrameworkCore;
using zhunting.DataAccess.Extensions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using System.Linq;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace zhunting.api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = "https://securetoken.google.com/zhunting-30577";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = "https://securetoken.google.com/zhunting-30577",
                        ValidateAudience = true,
                        ValidAudience = "zhunting-30577",
                        ValidateLifetime = true
                    };
                });

            services.AddCors(options => options.AddDefaultPolicy(options => { options.AllowAnyOrigin(); options.AllowAnyHeader(); options.AllowAnyMethod(); }));
            services.AddControllers(options =>
                    options.InputFormatters.Insert(0, GetJsonPatchInputFormatter())).AddNewtonsoftJson(options =>
                    {
                        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                        options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                    });

            services.AddDbContext<ZhuntingDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ZhuntingDev")));

            //services.AddIdentityServer().AddInMemoryApiScopes(AuthConfig.ApiScopes).AddInMemoryClients(AuthConfig.Clients);
            services.AddRepositories();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "zhunting.api", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "zhunting.api v1"));
            }

            //app.UseHttpsRedirection();
            app.UseCors();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            //app.UseIdentityServer();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private static NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter()
        {
            var builder = new ServiceCollection()
                .AddLogging()
                .AddMvc()
                .AddNewtonsoftJson()
                .Services.BuildServiceProvider();

            return builder
                .GetRequiredService<IOptions<MvcOptions>>()
                .Value
                .InputFormatters
                .OfType<NewtonsoftJsonPatchInputFormatter>()
                .First();
        }
    }
}
