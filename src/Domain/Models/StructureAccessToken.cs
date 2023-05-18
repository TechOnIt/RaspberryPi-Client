namespace TechOnIt.Domain.Models;

public class StructureAccessToken
{
    public string Token { get; set; }
    public DateTime TokenExpireAt { get; set; }

    public string RefreshToken { get; set; }
    public DateTime RefreshTokenExpireAt { get; set; }
}