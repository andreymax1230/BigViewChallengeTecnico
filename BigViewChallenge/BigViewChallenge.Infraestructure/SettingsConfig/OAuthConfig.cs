namespace BigViewChallenge.Infraestructure.SettingsConfig;

/// <summary>
/// Class Settings OAuth Token 
/// </summary>
public class OAuthConfig
{
    /// <summary>
    /// Issuer idnetity
    /// </summary>
    public string Aud { get; set; } = "";

    /// <summary>
    /// App Id call Identity
    /// </summary>
    public string Sub { get; set; } = "";
}
