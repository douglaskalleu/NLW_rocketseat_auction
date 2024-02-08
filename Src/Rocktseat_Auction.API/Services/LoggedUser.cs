using Rocktseat_Auction.API.Entities;
using Rocktseat_Auction.API.Interface;

namespace Rocktseat_Auction.API.Services;

public class LoggedUser : ILoggedUser
{
  private readonly IHttpContextAccessor _httpContext;
  private readonly IUserRepository _userRepository;

  public LoggedUser(IHttpContextAccessor httpContext, IUserRepository userRepository)
  {
    _httpContext = httpContext;
    _userRepository = userRepository;
  }

  public User User()
  {
    var token = TokenOnRequest();
    var email = FromBase64String(token);

    return _userRepository.GetUserByEmail(email);
  }

  private string TokenOnRequest() =>
    Utils.Utils.TokenOnRequest(_httpContext.HttpContext!);

  private string FromBase64String(string base64) =>
    Utils.Utils.FromBase64String(base64);
}
