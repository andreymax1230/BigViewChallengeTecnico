using BigViewChallenge.Infraestructure.SettingsConfig;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Encodings.Web;


namespace BigViewChallenge.Infraestructure.Auth;

/// <summary>
/// Handler Autentication Token Validate (Middleware)
/// </summary>
public class AuthenticationHandler :
    AuthenticationHandler<AuthenticationHandlerOptions>
{
    private readonly OAuthConfig _oAuthConfig;
    public AuthenticationHandler(IOptionsMonitor<AuthenticationHandlerOptions> options,
        ILoggerFactory logger, UrlEncoder encoder,
        ISystemClock clock, IOptions<OAuthConfig> oAuthConfig)
        : base(options, logger, encoder, clock)
    {
        _oAuthConfig = new()
        {
            Aud = oAuthConfig.Value.Aud,
            Sub = oAuthConfig.Value.Sub
        };
    }

    /// <summary>
    /// Handle Autorization
    /// </summary>
    /// <returns></returns>
    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        //check header first
        if (!Request.Headers
            .ContainsKey(Options.TokenHeaderName))
            return Task.FromResult(AuthenticateResult.Fail($"Missing header: {Options.TokenHeaderName}"));
        //get the header and validate
        string authorizationHeader = Request.Headers[Options.TokenHeaderName]!;
        if (!authorizationHeader.StartsWith("bearer", StringComparison.OrdinalIgnoreCase))
            return Task.FromResult(AuthenticateResult.Fail("Unauthorized"));

        string token = authorizationHeader.Substring("bearer".Length).Trim();
        if (string.IsNullOrEmpty(token))
            return Task.FromResult(AuthenticateResult.Fail("Unauthorized"));

        var validateToken = ValidateTokenIdentity(token);
        if (!validateToken.Item1)
            return Task.FromResult(AuthenticateResult.Fail("Unauthorized"));

        var claims = validateToken.Item2;
        var claimsIdentity = new ClaimsIdentity
            (claims, this.Scheme.Name);
        var claimsPrincipal = new ClaimsPrincipal
            (claimsIdentity);

        return Task.FromResult(AuthenticateResult.Success
            (new AuthenticationTicket(claimsPrincipal,
            this.Scheme.Name)));
    }

    /// <summary>
    /// Valiodate issue and appId from token
    /// </summary>
    /// <param name="jwt"></param>
    /// <returns></returns>
    Tuple<bool, List<Claim>> ValidateTokenIdentity(string jwt)
    {
        var handler = new JwtSecurityTokenHandler();
        var getToken = handler.ReadJwtToken(jwt);
        var audId = getToken.Payload["aud"]?.ToString();
        var subId = getToken.Payload["sub"]?.ToString();
        if (string.IsNullOrEmpty(audId) || audId != _oAuthConfig.Aud)
            return new Tuple<bool, List<Claim>>(false, new());
        if (string.IsNullOrEmpty(subId))
        {
            return new Tuple<bool, List<Claim>>(false, new());
        }
        if (string.IsNullOrEmpty(subId) || subId != _oAuthConfig.Sub)
            return new Tuple<bool, List<Claim>>(false, new());
        return new Tuple<bool, List<Claim>>(true, getToken.Claims.ToList());
    }
}