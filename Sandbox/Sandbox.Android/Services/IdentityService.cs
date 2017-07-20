using System;
using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Xamarin.Forms;
using Sandbox.Abstractions;
using Sandbox.Droid.Services;
using System.Diagnostics;

[assembly: Dependency(typeof(IdentityService))]
namespace Sandbox.Droid.Services
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
			if (authContext.TokenCache.ReadItems().Any())
				authContext = new AuthenticationContext(authContext.TokenCache.ReadItems().First().Authority);

			var uri = new Uri(returnUri);
			var platformParams = new PlatformParameters((Activity)Forms.Context);
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
