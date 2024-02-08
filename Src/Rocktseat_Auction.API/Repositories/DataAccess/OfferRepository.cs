using Rocktseat_Auction.API.Entities;
using Rocktseat_Auction.API.Interface;

namespace Rocktseat_Auction.API.Repositories.DataAccess;

public class OfferRepository : IOfferRepository
{
  private readonly RockseatAuctionDbContext _dbContext;

  public OfferRepository(RockseatAuctionDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public void Add(Offer offer)
  {
    _dbContext.Offers.Add(offer);
    _dbContext.SaveChanges();
  }
}
