namespace Rocktseat_Auction.API.UseCases.Offer.CreateOffer;

using Rocktseat_Auction.API.Communication.Requests;
using Rocktseat_Auction.API.Entities;
using Rocktseat_Auction.API.Interface;
using Rocktseat_Auction.API.Services;

public class CreateOfferUseCase
{
  private readonly ILoggedUser _loggedUser;
  private readonly IOfferRepository _offerRepository;

  public CreateOfferUseCase(ILoggedUser loggedUser, IOfferRepository offerRepository)
  {
    _loggedUser = loggedUser;
    _offerRepository = offerRepository;
  }

  public int Execute(int itemId, RequestCreateOfferJson request)
  {
    var offer = new Offer
    {
      CreatedOn = DateTime.Now,
      ItemId = itemId,
      Price = request.Price,
      UserId = _loggedUser.User().Id
    };

    _offerRepository.Add(offer);

    return offer.Id;
  }
}
