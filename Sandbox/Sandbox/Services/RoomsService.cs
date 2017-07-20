using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Sandbox.Services
{
    public class RoomsService : BaseGraphService
    {
        /// <summary>
        /// Gets the room directory.
        /// </summary>
        /// <returns>The room directory.</returns>
        /// <param name="geography">Geography.</param>
        public async Task<List<object>> GetRoomDirectory(string geography)
        {
			// TODO : https://graph.microsoft.com/v1.0/users/{userPrincipalName}/calendar/events

			//var queryUrl = $"{Endpoints.Calendar}";
			//var response = await GetHttpsEndpoint(queryUrl, token);
			//var result = JsonConvert.DeserializeObject<List<object>>(response);

			//return new Result<IEnumerable<object>>(result);

			throw new NotImplementedException();
        }
    }
}
