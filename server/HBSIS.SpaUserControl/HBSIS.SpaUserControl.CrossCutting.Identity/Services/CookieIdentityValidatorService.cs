﻿using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HBSIS.SpaUserControl.CrossCutting.Identity.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.Cookies;

namespace HBSIS.SpaUserControl.CrossCutting.Identity.Services
{
    public class CookieIdentityValidatorService
    {
        private static async Task<bool> VerifySecurityStampAsync(UserService manager, User user, CookieValidateIdentityContext context)
        {
            string stamp = context.Identity.FindFirstValue("AspNet.Identity.SecurityStamp");
            return (stamp == await manager.GetSecurityStampAsync(context.Identity.GetUserId()));
        }
        private static Task<bool> VerifyClientIdAsync(UserService manager, User user, CookieValidateIdentityContext context)
        {
            string clientId = context.Identity.FindFirstValue("AspNet.Identity.ClientId");
            if (!string.IsNullOrEmpty(clientId) && user.Clients.Any(c => c.ClientId.ToString() == clientId))
            {
                user.CurrentClientId = clientId;
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }

        public static Func<CookieValidateIdentityContext, Task> OnValidateIdentity(TimeSpan validateInterval, Func<UserService, User, Task<ClaimsIdentity>> regenerateIdentity)
        {
            return async context =>
            {
                DateTimeOffset utcNow = context.Options.SystemClock.UtcNow;
                DateTimeOffset? issuedUtc = context.Properties.IssuedUtc;
                bool expired = false;
                if (issuedUtc.HasValue)
                {
                    TimeSpan t = utcNow.Subtract(issuedUtc.Value);
                    expired = (t > validateInterval);
                }
                if (expired)
                {
                    var userManager = context.OwinContext.GetUserManager<UserService>();
                    string userId = context.Identity.GetUserId();
                    if (userManager != null && userId != null)
                    {
                        var user = await userManager.FindByIdAsync(userId);
                        bool reject = true;
                        if (user != null
                            && await VerifySecurityStampAsync(userManager, user, context)
                            && await VerifyClientIdAsync(userManager, user, context))
                        {
                            reject = false;
                            if (regenerateIdentity != null)
                            {
                                ClaimsIdentity claimsIdentity = await regenerateIdentity(userManager, user);
                                if (claimsIdentity != null)
                                {
                                    context.OwinContext.Authentication.SignIn(new ClaimsIdentity[]
                                    {
                                        claimsIdentity
                                    });
                                }
                            }
                        }
                        if (reject)
                        {
                            context.RejectIdentity();
                            context.OwinContext.Authentication.SignOut(new string[]
                            {
                                context.Options.AuthenticationType
                            });
                        }
                    }
                }
            };
        }
    }
}
