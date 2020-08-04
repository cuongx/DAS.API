using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAS.BAL;
using DAS.BAL.Interface;
using DAS.DAL;
using DAS.DAL.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DAS.API
{
    public class Startup
    {
        private readonly IConfiguration config;

        public Startup(IConfiguration config)
        {
            this.config = config;
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IPublishingRepository, PublishingRepository>();
            services.AddScoped<IPublishingService, PublishingService>();
            services.AddScoped<IBooksRepository, BooksRepository>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();  
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Book/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Book}/{action=Index}/{id?}");
            //});
        }
    }
}
