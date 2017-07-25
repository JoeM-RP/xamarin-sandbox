using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ModernHttpClient;
using Newtonsoft.Json;
using Common.Models;
using Common.Output;

namespace Sandbox.Services
{
    public abstract class BaseHttpService
    {
		internal async Task<string> GetHttpsEndpoint(string endpoint, string token)
		{
			using (HttpClient client = new HttpClient(new NativeMessageHandler()))
			{
				client.Timeout = new TimeSpan(0, 2, 0);
				client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token);

				var response = await client.GetAsync(endpoint);
                Debug.WriteLine($"[GetHttpsResponse] Endpoint = {endpoint} Result = {response.ReasonPhrase}");

				if (response.IsSuccessStatusCode && response.Content != null)
				{
					return await response.Content.ReadAsStringAsync();
				}
				else
					return await HandleCallFailure(response);
			}
		}

		internal async Task<string> PutHttpsEndpoint(string endpoint, object model, string token)
		{
			using (HttpClient client = new HttpClient(new NativeMessageHandler()))
			{
				client.Timeout = new TimeSpan(0, 2, 0);
				client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token);

				var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
				var response = await client.PutAsync(endpoint, content);
				Debug.WriteLine($"[PutHttpsEndpoint] Result = {response.ReasonPhrase}");

				if (response.IsSuccessStatusCode && response.Content != null)
				{
					return await response.Content.ReadAsStringAsync();
				}
				else
					return await HandleCallFailure(response);
			}
		}

		internal async Task<string> PostHttpsEndpoint(string endpoint, object model, string token)
		{
			using (HttpClient client = new HttpClient(new NativeMessageHandler()))
			{
				client.Timeout = new TimeSpan(0, 2, 0);
				client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token);

				var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
				var response = await client.PostAsync(endpoint, content);
				Debug.WriteLine($"[PostHttpsEndpoint] Result = {response.ReasonPhrase}");

				if (response.IsSuccessStatusCode && response.Content != null)
				{
					return await response.Content.ReadAsStringAsync();
				}
				else
					return await HandleCallFailure(response);
			}
		}

		internal async Task<byte[]> GetHttpsByteArrayEndpoint(string endpoint, string token)
		{
			using (HttpClient client = new HttpClient(new NativeMessageHandler()))
			{
				client.Timeout = new TimeSpan(0, 2, 0);
				client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token);

				var response = await client.GetAsync(endpoint);
				Debug.WriteLine($"[GetHttpsResponse] Endpoint = {endpoint} Result = {response.ReasonPhrase}");

                if (response.IsSuccessStatusCode && response.Content != null)
                {
                    return await response.Content.ReadAsByteArrayAsync();
                }
                else
                    throw new NotImplementedException();
			}
		}

        /// <summary>
        /// Handles the call failure.
        /// </summary>
        /// <returns>The call failure.</returns>
        /// <param name="message">Message.</param>
        protected abstract Task<string> HandleCallFailure(HttpResponseMessage message);

    }
}
