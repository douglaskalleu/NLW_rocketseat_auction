using Microsoft.AspNetCore.Mvc;
using Rocktseat_Auction.API.Entities;
using Rocktseat_Auction.API.UseCases.Auction.GetCurrent;

namespace Rocktseat_Auction.API.Controllers;

public class AuctionController : BaseController
{
  [HttpGet]
  [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  public IActionResult GetCurrentAcution([FromServices]GetCurrentAcutionUseCase useCase)
  {
    var result = useCase.Execute();

    if (result is null)
      return NoContent();

    return Ok(result);
  }
}
