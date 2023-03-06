using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Sheenman.Api.Models.Foundetions.Guests;
using Xunit;

namespace Sheenmanapi.Test.Unit.Servies.Foundetions.Guests
{
    public partial class GuestServiesTests
    {
        [Fact]

        public async Task ShouldAddGuestAsync()
        {
            // Given
          
            Guest randomGuest = CreateRandomGuest();
            Guest inputGuest = randomGuest;
            Guest persistedGuest = inputGuest;
            Guest excepdetGuest = persistedGuest.DeepClone();

            this.StoregeBrokerMock.Setup(broker =>
            broker.InsertGuestAsync(inputGuest)).ReturnsAsync(persistedGuest);
            
            // When
            
            Guest actualGuest = await this.guestServies
                .AddGuestAsync(inputGuest);

            // Then 

            actualGuest.Should().BeEquivalentTo(persistedGuest);

            this.StoregeBrokerMock.Verify(broker =>
            broker.InsertGuestAsync(inputGuest), Times.Once());

            this.StoregeBrokerMock.VerifyNoOtherCalls();
        }

      
    }
}
