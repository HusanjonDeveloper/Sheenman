//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers 
// Free ToUse Comfort and Peace 
//===================================================
using EFxceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace Sheenman.Api.Brokers.Storeges
{
    public partial class StoregesBroker : EFxceptionsContext
    {
        private readonly IConfiguration configuration;

        public StoregesBroker(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.Database.Migrate();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString =
                this.configuration.GetConnectionString(name: "DefoultConnetion");
           
            optionsBuilder.UseSqlServer(connectionString);

        }

        public override void Dispose() {}

    }
}
