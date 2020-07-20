using Autofac;
using MAVN.Persistence.PostgreSQL.Legacy;
using MAVN.Service.Tiers.Domain.Repositories;
using MAVN.Service.Tiers.MsSqlRepositories.Repositories;

namespace MAVN.Service.Tiers.MsSqlRepositories
{
    public class AutofacModule : Module
    {
        private readonly string _connectionString;

        public AutofacModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterPostgreSQL(
                _connectionString,
                connString => new DataContext(connString, false),
                dbConn => new DataContext(dbConn));

            builder.RegisterType<CustomerTiersRepository>()
                .As<ICustomerTiersRepository>()
                .SingleInstance();

            builder.RegisterType<TiersRepository>()
                .As<ITiersRepository>()
                .SingleInstance();

            builder.RegisterType<CustomerBonusesRepository>()
                .As<ICustomerBonusesRepository>()
                .SingleInstance();
        }
    }
}
