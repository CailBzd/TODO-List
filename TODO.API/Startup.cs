using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using TODO.Domain.Interfaces;
using TODO.Domain.Models;
using TODO.Domain.Services;
using TODO.Infra.Contexts;
using TODO.Infra.Repositories;

namespace TODO.API
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TODO.API", Version = "v1" });
            });

            //Possibilit� de faire un fichier d'extention de configurations
            //Ajout du context
            services.AddDbContext<TODOContext>(options =>
            {
                options.UseInMemoryDatabase("TODO.API");
            });
            //Ajout des repos
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ITaskRepository, TaskRepository>();
            //Ajout des services
            services.AddTransient<AuthenticateUser>();
            services.AddTransient<AddTask>();
            services.AddTransient<GetTasksByUser>();
            //Ajout des settings
            services.Configure<string>(Configuration.GetSection("Jwt"));
            //Ajout de l'authentification
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, TODOContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TODO.API v1"));
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            SeedData(context);
        }

        private void SeedData(TODOContext context)
        {
            var user = new User
            {
                Id = new Guid(),
                Username = "Pierre",
                Password = "0123456789",
                Tasks = new List<TaskItem>()
                {
                    new TaskItem{
                    Id = new Guid(),
                    Libelle = "Todo item 1",
                    Completed = false,
                    DateCreated = DateTime.Now.AddDays(-1)
                    },
                    new TaskItem{
                    Id = new Guid(),
                    Libelle = "Todo item 2",
                    Completed = false,
                    DateCreated = DateTime.Now.AddHours(-1)
                    },
                    new TaskItem{
                    Id = new Guid(),
                    Libelle = "Todo item 3",
                    Completed = false,
                    DateCreated = DateTime.Now.AddYears(-1)
                    },
                    new TaskItem{
                    Id = new Guid(),
                    Libelle = "Todo item 4",
                    Completed = false,
                    DateCreated = DateTime.Now
                    }
                }
            };

            context.Users.Add(user);

            context.SaveChanges();
        }
    }
}
