using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Site.Services;


namespace aspnetcoreapp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IGetRandomNumber, RandomNumberService>();
            services.AddTransient<IGetWinningNameService, WinningNameService>();

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Error);

            app.UseStaticFiles();
            
            app.UseExceptionHandler("/error");
            app.UseStatusCodePagesWithRedirects("/error/");

            app.UseMvc(routes =>
            {
            routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            // app.Run(context =>
            // {
            //     return context.Response.WriteAsync("Hello from ASP.NET Core!");
            // });
        }
    }
}