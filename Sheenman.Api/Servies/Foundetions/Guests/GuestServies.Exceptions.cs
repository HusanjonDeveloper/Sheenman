//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers 
// Free ToUse Comfort and Peace 
//===================================================

using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Sheenman.Api.Models.Foundetions.Guests;
using Sheenman.Api.Servies.Foundetions.Guests.Exceptions;
using Xeptions;

namespace Sheenman.Api.Servies.Foundetions.Guests
{
    public partial class GuestServies
    {
        private delegate ValueTask<Guest> ReturningGuestFunction();

        private async ValueTask<Guest> TryCatch(ReturningGuestFunction returningGuestFunction)
        {
            try
            {
                return await returningGuestFunction();
            }
            catch (NullGuestExceptions nullGuestExceptions)
            {
                throw CreateAndLogValidationException(nullGuestExceptions);
            }
            catch(InvalidGuestException invalidGuestException)
            {
                throw CreateAndLogValidationException(invalidGuestException);
            }
            catch (SqlException sqlException)
            {
                var  faildGuestStorageException = new FaildGuestStorageException(sqlException);
                throw CreateAndLogCriticalDepencyException(faildGuestStorageException);
            }
        }

        private GuestValidationException CreateAndLogValidationException(Xeption xeption)
        {
            var guestValidationException =
                  new GuestValidationException(xeption);

            this.loggingBroker.LogError(guestValidationException);
            return guestValidationException;
        }

        private GuestDependencyException CreateAndLogCriticalDepencyException(Xeption xeption)
        {
            var guestDependencyException = new GuestDependencyException(xeption);
           this.loggingBroker.LogCritical(guestDependencyException);

            return guestDependencyException;
        }
    }
}
