namespace Nur.Store2025.Security.Config;

public class JwtOptions
{
    public string SecretKey { get; set; }
    public bool ValidateIssuer { get; set; }
    public bool ValidateAudience { get; set; }
    public string ValidIssuer { get; set; }
    public string ValidAudience { get; set; }
    public bool ValidateLifetime { get; set; }
    public long Lifetime { get; set; }

    public JwtOptions()
    {
        SecretKey = "";
        ValidIssuer = "";
        ValidAudience = "";
    }
}
