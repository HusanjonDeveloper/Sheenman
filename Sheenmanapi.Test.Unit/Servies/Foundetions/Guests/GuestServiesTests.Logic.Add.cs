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
            Guest storageGuest = inputGuest;
            Guest excepdetGuest = storageGuest.DeepClone();

            this.StoregeBrokerMock.Setup(broker =>
            broker.InsertGuestAsync(inputGuest)).ReturnsAsync(storageGuest);
            
            // When
            
            Guest actualGuest = await this.guestServies
                .AddGuestAsync(inputGuest);

            // Then 

            actualGuest.Should().BeEquivalentTo(storageGuest);

            this.StoregeBrokerMock.Verify(broker =>
            broker.InsertGuestAsync(inputGuest), Times.Once());

            this.StoregeBrokerMock.VerifyNoOtherCalls();

        }

      
    }
}
