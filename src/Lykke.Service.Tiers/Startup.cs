using JetBrains.Annotations;
using Lykke.Sdk;
using Lykke.Service.Tiers.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;

namespace Lykke.Service.Tiers
{
    [UsedImplicitly]
    public class Startup
    {
        private readonly LykkeSwaggerOptions _swaggerOptions = new LykkeSwaggerOptions
        {
            ApiTitle = "Tiers API", ApiVersion = "v1"
        };

        [UsedImplicitly]
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            return services.BuildServiceProvider<AppSettings>(options =>
            {
                options.SwaggerOptions = _swaggerOptions;

                options.Logs = logs =>
                {
                    logs.AzureTableName = "TiersLog";
                    logs.AzureTableConnectionStringResolver = settings => settings.TiersService.Db.LogsConnectionString;
                };

                options.Extend = (serviceCollection, settings) =>
                {
                    serviceCollection.AddAutoMapper(typeof(AutoMapperProfile),
                        typeof(MsSqlRepositories.AutoMapperProfile));
                };
            });
        }

        [UsedImplicitly]
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IConfigurationProvider mapper)
        {
            mapper.AssertConfigurationIsValid();

            app.UseLykkeConfiguration(options => { options.SwaggerOptions = _swaggerOptions; });
        }
    }
}
