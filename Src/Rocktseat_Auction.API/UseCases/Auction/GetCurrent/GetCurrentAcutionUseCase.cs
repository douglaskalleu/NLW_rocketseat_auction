namespace Rocktseat_Auction.API.UseCases.Auction.GetCurrent;

using Rocktseat_Auction.API.Entities;
using Rocktseat_Auction.API.Interface;

public class GetCurrentAcutionUseCase
{

  private readonly IAuctionRepository _auctionRepository;

  public GetCurrentAcutionUseCase(IAuctionRepository auctionRepository)
  {
    _auctionRepository = auctionRepository;
  }

  public Auction? Execute()
  {
    return _auctionRepository.GetCurrent();
  }
}