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
    public class GuestServies : IGuestServies
    {
        private readonly IStoregesBroker storegesBroker;
        private readonly ILoggingBroker loggingBroker;

        public GuestServies(IStoregesBroker storegesBroker) =>
            this.storegesBroker = storegesBroker;

        public GuestServies(IStoregesBroker storegesBroker, ILoggingBroker loggingBroker)
        {
            this.storegesBroker = storegesBroker;
            this.loggingBroker = loggingBroker;
        }

        public async ValueTask<Guest> AddGuestAsync(Guest guest)
        {
            try
            {
            if(guest is null)
            {
                throw new NullGuestExceptions();

            }
              return await this.storegesBroker.InsertGuestAsync(guest);

            }
            catch (NullGuestExceptions nullGuestExceptions)
            {
                var guestValidationException =
                    new GuestValidationException(nullGuestExceptions);
              
                this.loggingBroker.LogError(guestValidationException);

                throw guestValidationException;
            }


        }

    }
}
