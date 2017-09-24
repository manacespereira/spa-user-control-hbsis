using System;
using Microsoft.Owin.Security.Infrastructure;

namespace HBSIS.SpaUserControl.WebApi.Security
{
    public class RefreshTokenProvider : AuthenticationTokenProvider
	{
		public override void Create(AuthenticationTokenCreateContext context)
		{
			// Expiration time in seconds
			var expire = 6 * 60 * 60;
			context.Ticket.Properties.ExpiresUtc = new DateTimeOffset(DateTime.Now.AddSeconds(expire));
			context.SetToken(context.SerializeTicket());
		}

		public override void Receive(AuthenticationTokenReceiveContext context)
		{
			context.DeserializeTicket(context.Token);
		}
	}
}