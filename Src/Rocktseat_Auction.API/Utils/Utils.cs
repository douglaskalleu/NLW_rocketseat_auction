namespace Rocktseat_Auction.API.Utils;

public static class Utils
{
  public static string TokenOnRequest(HttpContext context)
  {
    var authentication = context.Request.Headers.Authorization.ToString();

    if (string.IsNullOrEmpty(authentication))
      throw new Exception("Nao tem o trem de logar ai mano");

    return authentication["Bearer ".Length..];
  }

  public static string FromBase64String(string base64)
  {
    var date = Convert.FromBase64String(base64);
    return System.Text.Encoding.UTF8.GetString(date);
  }
}
