using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Umc.VigiFlow.Adapters.Secondary.ConsoleLogger;
using Umc.VigiFlow.Adapters.Secondary.MongoDBAuditTrailPersistance;
using Umc.VigiFlow.Adapters.Secondary.MongoDBPersistance;
using Umc.VigiFlow.Adapters.Secondary.SimpleCommandBus;
using Umc.VigiFlow.Adapters.Secondary.SimpleCommandValidator;
using Umc.VigiFlow.Adapters.Secondary.SimpleEventBus;
using Umc.VigiFlow.Core.VigiFlowCore;

namespace Umc.VigiFlow.Adapters.Primary.APIApp
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            // Setup DI for VigiFlowCore
            containerBuilder.RegisterModule(new VigiFlowCoreAutofacModule());

            // Setup DI for Secondary adapters used
            RegisterSecondaryAdapters(containerBuilder);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

        #region Private

        private static void RegisterSecondaryAdapters(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule<SimpleCommandBusAutofacModule>();
            containerBuilder.RegisterModule<SimpleEventBusAutofacModule>();
            containerBuilder.RegisterModule<MongoDBPersistanceAutofacModule>();
            containerBuilder.RegisterModule<ConsoleLoggerAutofacModule>();
            containerBuilder.RegisterModule<SimpleCommandValidatorAutofacModule>();
            containerBuilder.RegisterModule<MongoDBAuditTrailPersistanceAutofacModule>();
        }

        #endregion Private
    }
}
