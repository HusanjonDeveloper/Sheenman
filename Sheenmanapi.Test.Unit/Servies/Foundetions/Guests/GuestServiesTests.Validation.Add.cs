//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers 
// Free ToUse Comfort and Peace 
//===================================================

using Moq;
using Sheenman.Api.Models.Foundetions.Guests;
using Sheenman.Api.Servies.Foundetions.Guests.Exceptions;
using Xunit;

namespace Sheenmanapi.Test.Unit.Servies.Foundetions.Guests
{
    public partial class GuestServiesTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnAddIfGuestIsNullAndLogItAsync()
        {
            // Given 

            Guest nullGuest = null;
            var nullGuestException = new NullGuestExceptions();

            var expectedGuestValidationException = 
                new GuestValidationException(nullGuestException);

            // When

            ValueTask<Guest> addGuestTask =
                this.guestServies.AddGuestAsync(nullGuest);

            // Then

            await Assert.ThrowsAsync<GuestValidationException>(() =>
            addGuestTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
            broker.LogError(It.Is(SomeExceptionAs(expectedGuestValidationException))),
            Times.Once);

            this.StoregeBrokerMock.Verify(broker =>
            broker.InsertGuestAsync(It.IsAny<Guest>()),
            Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.StoregeBrokerMock.VerifyNoOtherCalls();
           
        }
    }
}
