//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers 
// Free To Use To find Comfort and Peace 
//===================================================

using System.Linq.Expressions;
using FluentAssertions;
using Moq;
using Sheenman.Api.Brokers.Loggings;
using Sheenman.Api.Brokers.Storeges;
using Sheenman.Api.Models.Foundetions.Guests;
using Sheenman.Api.Servies.Foundetions.Guests;
using Tynamix.ObjectFiller;
using Xeptions;
using Xunit;

namespace Sheenmanapi.Test.Unit.Servies.Foundetions.Guests
{
    public partial class GuestServiesTests
    {
        private readonly Mock<IStoregesBroker> StoregeBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly IGuestServies guestServies;

        public GuestServiesTests()
        {
           this.StoregeBrokerMock = new Mock<IStoregesBroker>();
            this.loggingBrokerMock= new Mock<ILoggingBroker>();

            this.guestServies = new GuestServies(
                storegesBroker: this.StoregeBrokerMock.Object,
                 loggingBroker: this.loggingBrokerMock.Object);
        }

        private Guest CreateRandomGuest() =>
            CreateGuestFiller(dates:GetRandomDateTimeOffset()).Create();
        private DateTimeOffset GetRandomDateTimeOffset() =>
            new DateTimeRange(earliestDate: DateTime.UnixEpoch).GetValue();

        private static int GetRandomNumber() =>
            new IntRange(2, 9).GetValue();

        private static T GetInvalidEnum<T>()
        {
            int randomNumber = GetRandomNumber();

            while (Enum.IsDefined(typeof(T), randomNumber) is true)
            {
                randomNumber = GetRandomNumber();
            }
            return (T)(object)randomNumber;
        }

        private Expression<Func<Xeption, bool>> SomeExceptionAs(Xeption expectedGuestValidationException)
        {
            return actualException =>
                actualException.Message == expectedGuestValidationException.Message
                && actualException.InnerException.Message == expectedGuestValidationException.InnerException.Message
                && (actualException.InnerException as Xeption).DataEquals(expectedGuestValidationException.InnerException.Data);
        }
        private Filler<Guest> CreateGuestFiller(DateTimeOffset dates)
        {
            var filler = new Filler<Guest>();

            filler.Setup()
                .OnType<DateTimeOffset>().Use(dates);
           
            return filler;
        }

      
    }
}
