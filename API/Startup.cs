using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Homely.Infrastructure.Data;
using Homely.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using Homely.Services.Interfaces;
using Homely.Services;
using Homely.Core.Repository;

namespace API
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
            ConfigureHomelyServices(services);
            services.AddControllers();
        }

        private void ConfigureHomelyServices(IServiceCollection services)
        {

            //Add Service Layer
            services.AddScoped<IListingService, ListingService>();

            // Add Infrastructure Layer
            ConfigureDatabases(services);
            services.AddScoped(typeof( IListingRepository), typeof(ListingRepository));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        public void ConfigureDatabases(IServiceCollection services)
        {
            // use Homely database
            services.AddDbContext<HomelyContext>(c =>
                c.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


        }
    }
}
