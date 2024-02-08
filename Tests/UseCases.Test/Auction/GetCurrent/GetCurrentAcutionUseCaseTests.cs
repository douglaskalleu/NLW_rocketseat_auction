using Bogus;
using FluentAssertions;
using Moq;
using Rocktseat_Auction.API.Entities;
using Rocktseat_Auction.API.Enuns;
using Rocktseat_Auction.API.Interface;
using Rocktseat_Auction.API.UseCases.Auction.GetCurrent;
using Xunit;

namespace UseCases.Test.Auction.GetCurrent;
public class GetCurrentAcutionUseCaseTests
{
  [Fact]
  public void Execute_Success()
  {
    //Arrange
    var entity = new Faker<Rocktseat_Auction.API.Entities.Auction>()
      .RuleFor(auction => auction.Id, f => f.Random.Number(1, 10))
      .RuleFor(auction => auction.Name, f => f.Lorem.Word())
      .RuleFor(auction => auction.Starts, f => f.Date.Past())
      .RuleFor(auction => auction.Ends, f => f.Date.Future())
      .RuleFor(auction => auction.Items, (f, auction) => new List<Item>
      {
        new Item
        {
          Id = f.Random.Number(1, 10),
          Name = f.Commerce.ProductName(),
          Brand = f.Commerce.Department(),
          BasePrice = f.Random.Decimal(50, 1000),
          Condition = f.PickRandom<Condition>(),
          AuctionId = auction.Id,
        }
      }).Generate();

    var mock = new Mock<IAuctionRepository>();
    mock.Setup(i => i.GetCurrent()).Returns(entity);
    var useCase = new GetCurrentAcutionUseCase(mock.Object);

    //Act
    var auction = useCase.Execute();

    //Assert
    auction.Should().NotBeNull();
    auction.Id.Should().Be(entity.Id);
    auction.Name.Should().Be(entity.Name);
  }
}
