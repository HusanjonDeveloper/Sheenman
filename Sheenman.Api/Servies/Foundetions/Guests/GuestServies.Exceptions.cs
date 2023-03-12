//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers 
// Free ToUse Comfort and Peace 
//===================================================

using System;
using System.Threading.Tasks;
using EFxceptions.Models.Exceptions;
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
            catch(DuplicateKeyException duplicateKeyException)
            {
                var alreadyExistGuestException =
               new AlreadyExistGuestException(duplicateKeyException);

                throw CreateAndLogDependensyValidationException(alreadyExistGuestException);
            }
            catch(Exception exception)
            {
                var failedGuestServiceException =
                    new FailedGuestServiceException(exception);

                throw CreateAndLogServiceException(failedGuestServiceException);
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
        private GuestDependencyValidationException CreateAndLogDependensyValidationException(
            Xeption xeption)
        {
            var  guestDependencyValidationException =
                new GuestDependencyValidationException(xeption);

            this.loggingBroker.LogError(guestDependencyValidationException);
            return guestDependencyValidationException;
        }

        private GuestServiceException CreateAndLogServiceException(Xeption xeption)
        {
            var guestServiceException = new GuestServiceException(xeption);
            this.loggingBroker.LogError(guestServiceException);
            return guestServiceException;
        }

    }
}
