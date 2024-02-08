using Rocktseat_Auction.API.Entities;
using Rocktseat_Auction.API.Interface;

namespace Rocktseat_Auction.API.Repositories.DataAccess;

public class UserRepository : IUserRepository
{
  private readonly RockseatAuctionDbContext _dbContext;

  public UserRepository(RockseatAuctionDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public bool ExistUserWithEmail(string email)
  {
    return _dbContext.Users.Any(user => user.Email.Equals(email));
  }

  public User GetUserByEmail(string email)
  {
    return _dbContext.Users.First(user => user.Email.Equals(email));
  }
}
