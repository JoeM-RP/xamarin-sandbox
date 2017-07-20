using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using UIKit;
using Sandbox.Abstractions;
using Sandbox.iOS.Services;
using System.Diagnostics;

[assembly: Xamarin.Forms.Dependency(typeof(IdentityService))]
namespace Sandbox.iOS.Services
{
    public class IdentityService : IIdentityService
    {
		public async Task<AuthenticationResult> Authorize()
		{
			try
			{
                var data = await this.SignIn(App.AadAuthority, App.AppServiceUrl, App.AadApplicationId, App.AadRedirectUri);
				Debug.WriteLine($"[GetPrimaryUser] Success = {data.UserInfo.GivenName} {data.UserInfo.FamilyName}");

				return data;
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"[GetPrimaryUser] Error = {ex.Message}");
				throw;
			}
		}

		public async Task<AuthenticationResult> SignIn(string authority, string resource, string clientId, string returnUri)
		{
			var authContext = new AuthenticationContext(authority);
			if (authContext.TokenCache.ReadItems().Any(_ => _.Resource == resource))
				authContext = new AuthenticationContext(authContext.TokenCache.ReadItems().First(_ => _.Resource == resource).Authority);

			var controller = UIApplication.SharedApplication.KeyWindow.RootViewController;
			var uri = new Uri(returnUri);
			var platformParams = new PlatformParameters(controller);
			var authResult = await authContext.AcquireTokenAsync(resource, clientId, uri, platformParams);

			return authResult;
		}

		public void SignOut(string authority)
		{
			var authContext = new AuthenticationContext(authority);
			if (authContext.TokenCache.ReadItems().Any())
			{
				authContext.TokenCache.Clear();
			}
		}
    }
}
