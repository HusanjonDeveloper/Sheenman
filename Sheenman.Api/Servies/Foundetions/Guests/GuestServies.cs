//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers 
// Free To Use To find Comfort and Peace 
//===================================================

using System.Threading.Tasks;
using Sheenman.Api.Brokers.Storeges;
using Sheenman.Api.Models.Foundetions.Guests;

namespace Sheenman.Api.Servies.Foundetions.Guests
{
    public class GuestServies : IGuestServies
    {
        private readonly IStoregesBroker storegesBroker;

        public GuestServies(IStoregesBroker storegesBroker) =>
            this.storegesBroker = storegesBroker;

        public async ValueTask<Guest> AddGuestAsync(Guest guest) =>
            await this.storegesBroker.InsertGuestAsync(guest);

    }
}
