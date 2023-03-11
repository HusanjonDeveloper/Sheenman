//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers 
// Free To Use To find Comfort and Peace 
//===================================================

using Microsoft.Data.SqlClient;
using Moq;
using Sheenman.Api.Models.Foundetions.Guests;
using Sheenman.Api.Servies.Foundetions.Guests.Exceptions;
using Xunit;

namespace Sheenmanapi.Test.Unit.Servies.Foundetions.Guests
{
    public partial class GuestServiesTests
    {
        [Fact]

        public async Task ShouldThrowCriticalDependencyExceptionOnAddIfSqlErrorOccursAndLogItAsync()
        {
            // given 
            
            Guest someGuest = CreateRandomGuest();
            SqlException sqlException = GetSqlError();
            FaildGuestStorageException faildGuestStorageException =
                new FaildGuestStorageException(sqlException);

            GuestDependencyException guestDependencyException =
                new GuestDependencyException(faildGuestStorageException);

            this.StoregeBrokerMock.Setup(broker =>
            broker.InsertGuestAsync(someGuest))
                .ThrowsAsync(sqlException);

            // when 

            ValueTask<Guest> addGuestTask =
                this.guestServies.AddGuestAsync(someGuest);

            // then 

            await Assert.ThrowsAsync<GuestDependencyException>(()=>
            addGuestTask.AsTask());

            this.StoregeBrokerMock.Verify(broker =>
            broker.InsertGuestAsync(someGuest),
            Times.Once());

            Xeptions.Xeption expectedGuestDependencyException = null;
            this.loggingBrokerMock.Verify(broker =>
           broker.LogCritical(It.Is(SomeExceptionAs(
               expectedGuestDependencyException))),
               Times.Once);

            this.StoregeBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();

        }

    }
}
