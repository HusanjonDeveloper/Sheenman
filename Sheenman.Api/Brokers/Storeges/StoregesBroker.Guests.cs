//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers 
// Free ToUse Comfort and Peace 
//===================================================


using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Sheenman.Api.Models.Foundetions.Guests;

namespace Sheenman.Api.Brokers.Storeges
{
    public partial class StoregesBroker
    {
        public DbSet<Guest> Guests { get; set; }

        public async ValueTask<Guest> InsertGuestAsync(Guest guest)
        {
            using var broker =
                new StoregesBroker(this.configuration);

            EntityEntry<Guest> guestEntityEntry = 
                await broker.Guests.AddAsync(guest);
           
            await broker.SaveChangesAsync();

            return guestEntityEntry.Entity;
        }
    }

   

}
