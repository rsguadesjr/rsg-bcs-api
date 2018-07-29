using BCSProjectAPI.BusinessLayer.Manager;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace BCSProjectAPI.Providers
{
    public class MyAuthorizationServiceProvider : OAuthAuthorizationServerProvider
    {
        private readonly UserManager _userManager;

        public MyAuthorizationServiceProvider()
        {
            _userManager = new UserManager();
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();

            return Task.FromResult<object>(null);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            var user = _userManager.GetUserCredentials(context.UserName, context.Password);
            if (user != null)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, user.Role.RoleName));
                identity.AddClaim(new Claim("username", user.Username));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.Username));
                context.Validated(identity);
            }
            else
            {
                context.SetError("invalid_grant", "Provided username or password is incorrect");
            }
            return Task.FromResult<object>(null);
        }

        public override Task TokenEndpointResponse(OAuthTokenEndpointResponseContext context)
        {
            //var role = context.Identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;
            //context.AdditionalResponseParameters.Add("role", role);
            return base.TokenEndpointResponse(context);
        }
    }
}