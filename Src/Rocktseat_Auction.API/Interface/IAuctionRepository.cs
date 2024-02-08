using Rocktseat_Auction.API.Entities;

namespace Rocktseat_Auction.API.Interface;

public interface IAuctionRepository
{
  Auction? GetCurrent();
}
