using Rocktseat_Auction.API.Entities;

namespace Rocktseat_Auction.API.Interface;

public interface IOfferRepository
{
  void Add(Offer offer);
}
