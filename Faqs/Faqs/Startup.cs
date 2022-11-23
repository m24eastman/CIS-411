using Microsoft.EntityFrameworkCore;
using Faqs.Models;

namespace Faqs
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
                options.AppendTrailingSlash = true;
            });

            services.AddControllersWithViews();

            services.AddDbContext<FaqsContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("FaqsContext")));
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
            endpoints MapControllerRoute(
                name: "default",
   pattern: "{vontroller=Home}/{action=Index}/{id?}" );
            });
        }

    }
}