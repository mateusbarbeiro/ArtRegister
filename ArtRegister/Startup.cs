using ArtRegister.Application.Interfaces.Repositories.BaseRepositories;
using ArtRegister.Application.Interfaces.Repository;
using ArtRegister.Application.Interfaces.Services;
using ArtRegister.Application.Services;
using ArtRegister.Domain.Dtos;
using ArtRegister.Domain.Models;
using ArtRegister.Infrastructure.Context;
using ArtRegister.Infrastructure.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace ArtRegister
{
    /// <summary>
    /// Classe de criação do projeto
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configuração
        /// </summary>
        public IConfiguration Configuration { get; }

        static string XmlCommentsFilePath
        {
            get
            {
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
                return Path.Combine(basePath, fileName);
            }
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container. 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddCors();

            // Serviços
            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<ISectionsService, SectionsService>();

            // Repositórios
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IBaseDoubleRepository<>), typeof(BaseDoubleRepository<>));
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<ISectionsRepository, SectionsRepository>();

            // Mapeamento
            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.CreateMap<CreateProductsModel, Products>();
                config.CreateMap<UpdateProductsModel, Products>();
                config.CreateMap<Products, ProductsModel>();

                config.CreateMap<CreateSectionsModel, Sections>();
                config.CreateMap<UpdateSectionsModel, Sections>();
                config.CreateMap<Sections, SectionsModel>();
            }).CreateMapper());

            // Configuração da base
            services.AddDbContext<ApiContext>(options => {
                options.UseMySql(
                    Configuration.GetConnectionString("MyConnection"),
                    new MySqlServerVersion(new Version(8, 0, 11))
                );
            });

            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    "v1",
                    new OpenApiInfo 
                    { 
                        Title = "Art Register"
                    }
                );

                c.IncludeXmlComments(XmlCommentsFilePath);
            });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline. 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(
            IApplicationBuilder app, 
            IWebHostEnvironment env
        )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}"
                );
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(
                    "/swagger/v1/swagger.json",
                    "ArtRegister"
                );
            });
        }
    }
}
