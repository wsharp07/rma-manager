using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RmaManager.Data;
using Microsoft.AspNet.Routing;
using RmaManager.Data.Repository.Interface;
using RmaManager.Data.Repository;
using Newtonsoft.Json.Serialization;
using AutoMapper;
using RmaManager.Models;
using RmaManager.ViewModels;
using RmaManager.Mappings;

namespace RmaManager
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddJsonOptions(opt => 
                {
                    opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });
                
            services.AddEntityFramework()
                .AddSqlite()
                .AddDbContext<RmaContext>();
            
            // Register Seeds
            services.AddTransient<Seeds>();
            
            // Register Repositories
            RegisterRepositories(services);
        }
        
        public void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IRmaRepository, RmaRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, Seeds seeder)
        {
            // Add logging
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();
    
            app.UseStaticFiles();
            app.UseMvc(ConfigureRoutes);
            
            // Automapper
            Mapper.Initialize(RegisterMaps);
            
            seeder.EnsureSeedData();
        }
        
        private void ConfigureRoutes(IRouteBuilder config)
        {
            config.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" }
                );
        }
        
        private void RegisterMaps(IConfiguration config)
        {
            config.CreateMap<Rma,RmaViewModel>()
                .ForMember(x => x.HardwareTypeName, m => m.MapFrom(x => x.HardwareType.Name));
                
            config.CreateMap<RmaViewModel,Rma>().ConvertUsing<RmaVmToEntity>();
        }

        // Entry point for the application.
        public static void Main(string[] args) => Microsoft.AspNet.Hosting.WebApplication.Run<Startup>(args);
    }
}
