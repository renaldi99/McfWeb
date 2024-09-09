using System;
using System.Text;

namespace MfcWeb.Utility
{
	public static class RestUtils
	{
		public static object CallPost(string url, string request, string contentType, int timeout, params (string name, string value)[]? headers)
		{
			using (var handler = new HttpClientHandler())
			{
				using (var client = new HttpClient(handler))
				{
					if (headers?.Length > 0)
					{
						foreach (var head in headers)
						{
							client.DefaultRequestHeaders.Add(head.name, head.value);
						}
					}

					client.Timeout = TimeSpan.FromMinutes(timeout);
					var dataClient = new StringContent(request, Encoding.UTF8, contentType);
					var response = client.PostAsync(url, dataClient).Result;
					var responseContent = response.Content.ReadAsStringAsync().Result;
					return responseContent;
				}
			}
		}
	}
}

