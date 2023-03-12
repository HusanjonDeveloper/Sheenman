//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers 
// Free To Use To find Comfort and Peace 
//===================================================

using EFxceptions.Models.Exceptions;
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
        [Fact]
        public async Task ShouldThrowDependencyValidationOnAddIfDuplecateKeyErrorOccursAndLogItAsync()
        {
            // given 

            Guest someGuest = CreateRandomGuest();
            string someMessage = GetRandomString();
            
            DuplicateKeyException duplicateKeyException =
                new DuplicateKeyException(someMessage);

            var alreadyExistGuestException =
                new AlreadyExistGuestException(duplicateKeyException);

            var expecdetguestDependencyValidationException =
                new GuestDependencyValidationException(alreadyExistGuestException);

            this.StoregeBrokerMock.Setup(broker =>
            broker.InsertGuestAsync(someGuest))
                .ThrowsAsync(duplicateKeyException);

            // when 

            ValueTask<Guest> addGuestTask =
                this.guestServies.AddGuestAsync(someGuest);

            // then 

            await Assert.ThrowsAsync<GuestDependencyValidationException>(()=>
            addGuestTask.AsTask());

            this.StoregeBrokerMock.Verify(broker =>
            broker.InsertGuestAsync(someGuest),
            Times.Once);

            this.loggingBrokerMock.Verify(broker =>
             broker.LogError(It.Is(SomeExceptionAs(
                 expecdetguestDependencyValidationException))),
                 Times.Once);
                  
             this.StoregeBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnAddIfServiceErrorOccursAndLogItAsync()
        {
            // given 
            Guest someGuest = CreateRandomGuest();
            var serviceException = new Exception();

            var failedGuestServiceException =
                new FailedGuestServiceException(serviceException);

            var expectedGuestServiceException =
                new GuestServiceException(failedGuestServiceException);

            this.StoregeBrokerMock.Setup(broker =>
            broker.InsertGuestAsync(someGuest))
                .ThrowsAsync(serviceException);

            // when 

            ValueTask<Guest> addGuestTask =
                this.guestServies.AddGuestAsync(someGuest);

            // then
            
            await Assert.ThrowsAsync<GuestServiceException>(()=>
            addGuestTask.AsTask());


            this.StoregeBrokerMock.Verify(broker =>
            broker.InsertGuestAsync(someGuest),
            Times.Once);

            this.loggingBrokerMock.Verify(broker =>
            broker.LogError(It.Is(SomeExceptionAs(
                expectedGuestServiceException))),
                Times.Once);

            this.StoregeBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }

    }
}