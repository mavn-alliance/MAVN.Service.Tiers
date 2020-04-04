using Autofac;
using MAVN.Service.Tiers.Domain.Services;

namespace MAVN.Service.Tiers.DomainServices
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomersService>()
                .As<ICustomersService>()
                .SingleInstance();

            builder.RegisterType<ReportsService>()
                .As<IReportsService>()
                .SingleInstance();

            builder.RegisterType<TiersService>()
                .As<ITiersService>()
                .SingleInstance();
        }
    }
}
