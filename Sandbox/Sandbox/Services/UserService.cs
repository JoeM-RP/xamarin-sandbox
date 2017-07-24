using System;
using System.Net.Http;
using System.Threading.Tasks;
using Common.Enums;
using Common.Models;
using Common.Output;
using ModernHttpClient;
using Newtonsoft.Json;

namespace Sandbox.Services
{
    public class UserService : BaseHttpService, IUserService
    {
        public async Task<Result<MeModel>> GetUserInfo()
        {
            var token = App.Authorization.AccessToken;

			var queryUrl = $"https://graph.microsoft.com/v1.0/me/";
			var response = await GetHttpsEndpoint(queryUrl, token);
            var result = JsonConvert.DeserializeObject<MeModel>(response);

            return new Result<MeModel>(result);
        }

        public Task<Result<object>> GetUserPhoto()
        {
            throw new NotImplementedException();
        }

        protected override Task<string> HandleCallFailure(HttpResponseMessage message)
        {
            throw new NotImplementedException();
        }
    }
}
