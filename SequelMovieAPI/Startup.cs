using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using AutoMapper;
using Swashbuckle.AspNetCore.Swagger;
using SequelMovieAPI.Services;
using SequelMovieAPI.Models.Requests;

namespace SequelMovieAPI
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
            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SequelMovie API", Version = "v1" });
            });
            #region dependencyinjection
            var connection = Configuration.GetConnectionString("sequelmovie");
            services.AddDbContext<SequelMovieAPI.Database.sequelmovieContext>(options => options.UseMySQL(connection));
            services.AddScoped<ICRUDService<Models.Artiste, ArtisteSearchRequest, ArtisteUpsertRequest, ArtisteUpsertRequest>, ArtisteService>();
            services.AddScoped<ICRUDService<Models.ArtisteBand, ArtisteBandSearchRequest, ArtisteBandUpsertRequest, ArtisteBandUpsertRequest>, ArtisteBandService>();
            #endregion
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SequelMovie API V1");
                c.RoutePrefix = string.Empty;

            });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
