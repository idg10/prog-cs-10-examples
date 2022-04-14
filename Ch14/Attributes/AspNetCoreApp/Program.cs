using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

var builder = WebApplication.CreateBuilder(args);

// To be able to illustrate the use of the [Authorize] attribute, we need to
// enable Authorization, and for that to make any sense we need Authentication
// too. To avoid bringing in a load of extra complexity around user account
// handling, or configuring an external provider such as Azure AD, we use an
// extremely simple setup:
//
// We require HTTP Basic Authentication, and we accept any credentials.
//
// If the request doesn't have an Authorization header with a Basic scheme,
// we will reject the request with a 401, and a suitable WWW-Authenticate
// header. Some browsers will automatically prompt for credentials at that
// point, although some don't because they consider basic authentication to be
// insecure. (And in this example, they're right. The point of this example is
// to demonstrate attributes on a lambda, not how to secure a web site.)
//
// You won't see a prompt for credentials when fetching the root, because we've
// enabled anonymous access to that one URL. If, when you fetch, say,
// /items/42, you see a prompt, type in literally any username and password you
// like. This example only requires these credentials to be present, it doesn't
// care what they are.
//
// If your browser isn't going to handle basic authentication for you, you
// could run these PowerShell commands to invoke the endpoint:
//
//  $creds = Get-Credential
//  # (PowerShell will prompt you. Type any username and a bogus password)
//  iwr https://localhost:7225/items/42 -Authentication Basic -Credential $creds
//
// That will invoke the endpoint in a way that satisfies this very articifial
// auth setup. Or you could use any other tool capable of sending HTTP requests
// with basic authentication, e.g., the Postman tool.

builder.Services
    .AddAuthentication("Basic")
    .AddScheme<AuthenticationSchemeOptions, VeryBasic>("Basic", null);
builder.Services.AddAuthorization(auth =>
    auth.AddPolicy("Basic", pb => pb.RequireAuthenticatedUser()));

var app = builder.Build();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

// This isn't part of the example in the book, but it's here so that F5 will
// run the site without an error. The [AllowAnonymous] attribute here enables
// access to the root page without credentials.
app.MapGet("/", [AllowAnonymous] () =>
    $"Try getting /items/42 (requires basic auth; any credentials will do)");

app.MapGet(
    "/items/{id}",
    [Authorize] ([FromRoute] int id) => $"Item {id} requested");

app.Run();

/// <summary>
/// A dangerously unsecure basic authentication handler for demonstration
/// purposes only.
/// </summary>
/// <remarks>
/// This
/// </remarks>
class VeryBasic : AuthenticationHandler<AuthenticationSchemeOptions>
{
    public VeryBasic(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock)
        : base(options, logger, encoder, clock)
    {
    }

    protected override Task HandleChallengeAsync(AuthenticationProperties properties)
    {
        // For some browsers, the presence of this WWWAuthenticate header will
        // cause them to prompt the user for a username and password.
        Response.StatusCode = 401;
        Response.Headers.WWWAuthenticate = "Basic";

        return Task.CompletedTask;
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (AuthenticationHeaderValue.TryParse(Request.Headers.Authorization, out var authHeader))
        {
            if (authHeader.Scheme == "Basic" && authHeader.Parameter is not null)
            {
                byte[] credBytes = Convert.FromBase64String(authHeader.Parameter);
                string credentials = Encoding.UTF8.GetString(credBytes);
                string username = credentials[0..credentials.IndexOf(':')];

                var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username) }, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);

                var ticket = new AuthenticationTicket(principal, Scheme.Name);

                return Task.FromResult(AuthenticateResult.Success(ticket));
            }
            return Task.FromResult(AuthenticateResult.Fail("Authorization scheme must be Basic"));
        }
        return Task.FromResult(AuthenticateResult.Fail("Authorization header not present"));
    }
}