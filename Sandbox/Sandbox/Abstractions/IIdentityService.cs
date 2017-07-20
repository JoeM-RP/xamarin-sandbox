using System;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Sandbox.Abstractions
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> Authorize();
		Task<AuthenticationResult> SignIn(string authority, string resource, string clientId, string returnUri);
		void SignOut(string authority);
    }
}
