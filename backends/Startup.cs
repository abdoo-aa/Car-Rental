using backend.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend
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
            services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            return Task.CompletedTask;
                        }
                    };
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["JwtSettings:Issuer"],
                        ValidAudience = Configuration["JwtSettings:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSettings:Key"]))
                    };
                });
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularApp",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:4200") // Allow Angular app
                              .AllowAnyHeader()
                              .AllowAnyMethod()
                              .AllowCredentials();
                    });
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("User", policy => policy.RequireRole("User"));
                options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
            });


            services.AddControllers();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "backend", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "backend v1"));
            }
            

            app.UseHttpsRedirection();
            app.UseStaticFiles(); // Enable serving static files
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("AllowAngularApp");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
