using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Rocktseat_Auction.API.Interface;

namespace Rocktseat_Auction.API.Filters;

public class AuthenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter
{
  private readonly IUserRepository _userRepository;

  public AuthenticationUserAttribute(IUserRepository userRepository)
  {
    _userRepository = userRepository;
  }

  public void OnAuthorization(AuthorizationFilterContext context)
  {
    try
    {
      var token = TokenOnRequest(context.HttpContext);
      var email = FromBase64String(token);
      var exist = _userRepository.ExistUserWithEmail(email);

      if (!exist)
        context.Result = new UnauthorizedObjectResult("E-mail não ta na base maluco");
    }
    catch (Exception ex)
    {
      context.Result = new UnauthorizedObjectResult(ex.Message);
    }
  }

  private string TokenOnRequest(HttpContext context) =>
    Utils.Utils.TokenOnRequest(context);

  private string FromBase64String(string base64) =>
    Utils.Utils.FromBase64String(base64);
}
