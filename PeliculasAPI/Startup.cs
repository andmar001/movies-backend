using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PeliculasAPI.Controllers;
using PeliculasAPI.Filtros;
using PeliculasAPI.Repositorio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasAPI
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
            services.AddResponseCaching();
            //inversión de dependencias
            services.AddSingleton<IRepositorio, RepositorioEnMemoria>();
            services.AddTransient<WeatherForecastController>();
            //configurar filtro de accion
            services.AddTransient<MiFiltroDeAccion>();
            services.AddControllers(options =>
            {
                //filtro de exepcion a nivel global - para ver los errores ocurridos en un log
                options.Filters.Add(typeof(FiltroDeExcepcion));
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PeliculasAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
                    IWebHostEnvironment env,
                    ILogger<Startup>logger)
        {
            // guardar en un log todas las respuestas del web api
            app.Use(async (context, next) =>
            {
                using (var swapStream = new MemoryStream())
                {
                    var respuestaOriginal = context.Response.Body;
                    context.Response.Body = swapStream;

                    await next.Invoke();

                    swapStream.Seek(0, SeekOrigin.Begin);
                    string respuesta = new StreamReader(swapStream).ReadToEnd();
                    swapStream.Seek(0, SeekOrigin.Begin);

                    await swapStream.CopyToAsync(respuestaOriginal);
                    context.Response.Body = respuestaOriginal;

                    logger.LogInformation(respuesta);
                }
            });

            // interceptando en el endpoint especifico mapa1
            app.Map("/mapa1", (app) =>
            {
                app.Run(async context =>
                {
                    await context.Response.WriteAsync("Estoy interceptando el pipeline");
                });
            });

            //interceptar todos los proceso
            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Estoy interceptando el pipeline");
            //});

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PeliculasAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //middleware para caching
            app.UseResponseCaching();

            // middleware de autenticación
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
