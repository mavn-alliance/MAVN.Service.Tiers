using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Numerics;
using Falcon.Numerics;
using JetBrains.Annotations;
using Lykke.Common.MsSql;
using Lykke.Service.Tiers.MsSqlRepositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lykke.Service.Tiers.MsSqlRepositories
{
    public class DataContext : MsSqlContext
    {
        internal const string Schema = "tiers";

        public DbSet<CustomerTierEntity> CustomerTiers { get; set; }
        public DbSet<TierEntity> Tiers { get; set; }
        public DbSet<CustomerBonusesEntity> CustomerBonuses { get; set; }

        // for EF migrations
        [UsedImplicitly]
        public DataContext()
            : base(Schema)
        {
        }

        public DataContext(string connectionString, bool isTraceEnabled)
            : base(Schema, connectionString, isTraceEnabled)
        {
        }

        public DataContext(DbConnection dbConnection)
            : base(Schema, dbConnection)
        {
        }

        protected override void OnLykkeModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TierEntity>()
                .HasMany<CustomerTierEntity>()
                .WithOne()
                .HasForeignKey(o => o.TierId);

            modelBuilder.Entity<CustomerBonusesEntity>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<CustomerBonusesEntity>()
                .HasKey(x => x.CustomerId);

            modelBuilder.Entity<TierEntity>()
                .HasData(new List<TierEntity>
                {
                    new TierEntity(new Guid("e5538c22-3f19-489a-8eed-0549b84a47d2"), "Black", new Money18(BigInteger.Parse("0"), 0)),
                    new TierEntity(new Guid("af3804ef-faf2-47b0-b6f6-66100f3bcdd4"), "Silver", new Money18(BigInteger.Parse("100000000000000000000"), 0)),
                    new TierEntity(new Guid("df6e1941-0828-4424-9ed5-451d73139bed"), "Gold", new Money18(BigInteger.Parse("200000000000000000000"), 0)),
                    new TierEntity(new Guid("4c3cd4ce-98eb-487d-bef8-7e0ee3801ecc"), "Platinum", new Money18(BigInteger.Parse("300000000000000000000"), 0))
                });
        }
    }
}
