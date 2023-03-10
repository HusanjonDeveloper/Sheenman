//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers 
// Free To Use To find Comfort and Peace 
//===================================================

using System.Threading.Tasks;
using Sheenman.Api.Brokers.Loggings;
using Sheenman.Api.Brokers.Storeges;
using Sheenman.Api.Models.Foundetions.Guests;
using Sheenman.Api.Servies.Foundetions.Guests.Exceptions;

namespace Sheenman.Api.Servies.Foundetions.Guests
{
    public partial class GuestServies : IGuestServies
    {
        private readonly IStoregesBroker storegesBroker;
        private readonly ILoggingBroker loggingBroker;

        public GuestServies(
            IStoregesBroker storegesBroker,
            ILoggingBroker loggingBroker) 
        {
            this.storegesBroker = storegesBroker;
            this.loggingBroker = loggingBroker;
        }

        public  ValueTask<Guest> AddGuestAsync(Guest guest) =>
            TryCatch(async () =>
            {

            ValidateGuestNotNull(guest);
            return await this.storegesBroker.InsertGuestAsync(guest);

            });

    }
}
