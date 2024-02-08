using Bogus;
using FluentAssertions;
using Moq;
using Rocktseat_Auction.API.Communication.Requests;
using Rocktseat_Auction.API.Entities;
using Rocktseat_Auction.API.Interface;
using Rocktseat_Auction.API.Services;
using Rocktseat_Auction.API.UseCases.Offer.CreateOffer;
using Xunit;

namespace UseCases.Test.Offer.CreateOffer;
public class CreateOfferUseCaseTests
{
  [Theory]
  [InlineData(1)]
  [InlineData(2)]
  [InlineData(3)]
  public void Execute_Success(int itemId)
  {
    //Arrange
    var request = new Faker<RequestCreateOfferJson>()
      .RuleFor(request => request.Price, f => f.Random.Decimal(1, 10)).Generate();

    var offerRepository = new Mock<IOfferRepository>();
    var loggedUser = new Mock<ILoggedUser>();
    loggedUser.Setup(i => i.User()).Returns(new User());
    var useCase = new CreateOfferUseCase(loggedUser.Object, offerRepository.Object);

    // Act
    var act = () => useCase.Execute(itemId, request);

    // Assert
    act.Should().NotThrow();
  }
}
