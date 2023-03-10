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

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]

        public async Task ShouldThrowValidationExceptionOnAddIfGuestIsInvalidAndLogItAsync(
         string invalindText)
        {
            // given 
            var invalindGuest = new Guest
            {
                FristName = invalindText
            };

            var invalidGuestException = new InvalidGuestException();

            invalidGuestException.AddData(
                key: nameof(Guest.id),
                values: "Id is requred");

            invalidGuestException.AddData(
                key: nameof(Guest.FristName),
                values: "Text is requred");

            invalidGuestException.AddData(
                key: nameof(Guest.LastName),
                values: "Text is requred");
            invalidGuestException.AddData(
                key: nameof(Guest.DateOgBrith),
                values: "Date");

                invalidGuestException.AddData(
            key: nameof(Guest.Adders),
            values: "Text is required");

            invalidGuestException.AddData(
                key: nameof(Guest.Email),
                values: "Text is required");

            var exceptedGuestValidationException =
                new GuestValidationException(invalidGuestException);

            // when 
            ValueTask<Guest> addGuestTask =
                this.guestServies.AddGuestAsync(invalindGuest);

            // then 

            await Assert.ThrowsAsync<GuestValidationException>(() =>
            addGuestTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
            broker.LogError(It.Is(SomeExceptionAs(
                exceptedGuestValidationException))),
                Times.Once());

            this.StoregeBrokerMock.Verify(broker =>
            broker.InsertGuestAsync(It.IsAny<Guest>()),
            Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.StoregeBrokerMock.VerifyNoOtherCalls();
            
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnAddIfGenderIsInvalidAndLogItAsync()
        {
            // given 
            Guest randomGuest = CreateRandomGuest();
            Guest invalidGuest = randomGuest;
            invalidGuest.Gender = GetInvalidEnum<GenderType>();
            var invalidGuestException = new InvalidGuestException();

            invalidGuestException.AddData(
                key: nameof(Guest.Gender),
                values: "Valiu is invalid");

            var exceptedGuestValidationException =
               new GuestValidationException(invalidGuestException);

            // when 

            ValueTask<Guest> addGuestTask =
                this.guestServies.AddGuestAsync(invalidGuest);

            // then 
            await Assert.ThrowsAsync<GuestValidationException>(() =>
             addGuestTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
                     broker.LogError(It.Is(SomeExceptionAs(
                         exceptedGuestValidationException))),
                             Times.Once);

            this.StoregeBrokerMock.Verify(broker =>
            broker.InsertGuestAsync(It.IsAny<Guest>()));

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.StoregeBrokerMock.VerifyNoOtherCalls();
        }

    }
}
