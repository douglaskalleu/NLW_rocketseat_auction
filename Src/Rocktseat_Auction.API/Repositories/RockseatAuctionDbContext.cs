using Microsoft.EntityFrameworkCore;
using Rocktseat_Auction.API.Entities;

namespace Rocktseat_Auction.API.Repositories;

public class RockseatAuctionDbContext : DbContext
{
  public RockseatAuctionDbContext(DbContextOptions options) : base(options) { }

  public DbSet<Auction> Auctions { get; set; }
  public DbSet<User> Users { get; set; }
  public DbSet<Offer> Offers { get; set; }

}
