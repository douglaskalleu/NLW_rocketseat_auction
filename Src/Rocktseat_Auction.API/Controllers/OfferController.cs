using Microsoft.AspNetCore.Mvc;
using Rocktseat_Auction.API.Communication.Requests;
using Rocktseat_Auction.API.Filters;
using Rocktseat_Auction.API.UseCases.Offer.CreateOffer;

namespace Rocktseat_Auction.API.Controllers;

[ServiceFilter(typeof(AuthenticationUserAttribute))]
public class OfferController : BaseController
{
  [HttpPost]
  [Route("{itemId}")]
  public IActionResult CreateOffer([FromRoute] int itemId,
                                  [FromBody]RequestCreateOfferJson request,
                                  [FromServices]CreateOfferUseCase useCase)
  {
    var id = useCase.Execute(itemId, request);
    return Created(string.Empty, id);
  }
}
