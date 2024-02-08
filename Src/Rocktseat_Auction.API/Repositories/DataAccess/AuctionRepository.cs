using Microsoft.EntityFrameworkCore;
using Rocktseat_Auction.API.Entities;
using Rocktseat_Auction.API.Interface;

namespace Rocktseat_Auction.API.Repositories.DataAccess;

public class AuctionRepository : IAuctionRepository
{
  private readonly RockseatAuctionDbContext _dbContext;

  public AuctionRepository(RockseatAuctionDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public Auction? GetCurrent()
  {
    var today = new DateTime(2024, 01, 25);

    return _dbContext
          .Auctions
          .Include(arg => arg.Items)
          .FirstOrDefault(arg => today >= arg.Starts && today <= arg.Ends);
  }
}
