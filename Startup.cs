namespace TheTjerrs
{
    using Microsoft.AspNetCore.Http;
    using JavaScriptEngineSwitcher.ChakraCore;
    using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
    using React.AspNet;
    using TheTjerrs.Models;
    using TheTjerrs;
    using JavaScriptEngineSwitcher.V8;

    public static class Startup
    {
        public static WebApplication InitializeApp(string [] args) 
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder);
            var app = builder.Build();
            Configure(app);
            return app; 

        }

        private static void ConfigureServices(WebApplicationBuilder builder)
        {
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //FIXED ERROR CONTROLLER
            builder.Services.AddDbContext<PIPOSTEST_Context>();
            builder.Services.AddControllersWithViews();

            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
          builder.Services.AddReact();

            // Make sure a JS engine is registered, or you will get an error!
            builder.Services.AddJsEngineSwitcher(options => options.DefaultEngineName = V8JsEngine.EngineName)
              .AddV8();





        }




        private static void Configure(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }







            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        }

   
    }
}
