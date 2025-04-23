using Microsoft.AspNetCore.Authentication;

namespace BigViewChallenge.Infraestructure.Auth;

/// <summary>
/// Options Autenbticaton Handler
/// </summary>
public class AuthenticationHandlerOptions : AuthenticationSchemeOptions
{
    /// <summary>
    /// Scheme Autentication
    /// </summary>
    public const string DefaultScheme = "AuthenticationScheme";

    /// <summary>
    /// Header Autorization (Bearer)
    /// </summary>
    public string TokenHeaderName { get; set; } = "Authorization";
}