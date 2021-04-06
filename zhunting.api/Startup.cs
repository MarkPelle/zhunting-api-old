using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using zhunting.DataAccess;
using Microsoft.EntityFrameworkCore;
using zhunting.DataAccess.Extensions;
using Microsoft.AspNetCore.Identity;
using zhunting.api.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using zhunting.api.Services.ServiceClasses;
using zhunting.api.Services.Interfaces;
using System.Text;

namespace zhunting.api
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
            services.AddScoped<ITokenService, TokenService>();
            services.AddAutoMapper(typeof(Startup));

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "https://localhost:5001";

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin API", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("Admin API", "AdminAPI");
                });
            });

            services.AddCors(options => options.AddDefaultPolicy(options => { options.AllowAnyOrigin(); options.AllowAnyHeader(); options.AllowAnyMethod(); }));
            services.AddControllers().AddNewtonsoftJson(options =>
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

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
    }
}
