using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using JobSearching.Data;
using JobSearching.Services;
using JobSearching.Services.Contracts;

namespace JobSearching
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
            services.AddMvc();
            /*services.AddDbContext<JobSearchingDbContext>(options =>
            options.UseSqlServer("Server =.\\SQLEXPRESS; " +
            "Database=JobSearching;Integrated Security=true"));*/
            services.AddScoped<IAdvertService, AdvertService>();
            services.AddScoped<IEmployerService, EmployeerService>();
            services.AddScoped<IVolunteerService, VolunteerService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
