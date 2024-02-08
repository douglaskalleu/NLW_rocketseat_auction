using Rocktseat_Auction.API.Entities;

namespace Rocktseat_Auction.API.Interface;

public interface IUserRepository
{
  User GetUserByEmail(string email);

  bool ExistUserWithEmail(string email);
}
