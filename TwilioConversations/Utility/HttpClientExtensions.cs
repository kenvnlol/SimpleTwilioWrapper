using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace TwilioConversations.Utility;

public static class HttpClientExtensions
{
    public static async Task<HttpResponseMessage> SendHttpRequestAsync(this HttpClient client, HttpMethod method, HttpContent? content = null, string? uri = null)
    {
        var request = new HttpRequestMessage(method, uri)
        {
            Content = content,
        };

        var response = await client.SendAsync(request);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Request failed with status code: {response.StatusCode}");
        }

        return response;
    }

    public static async Task<JsonElement> GetContentAsJsonElementAsync(this HttpResponseMessage response)
    {
        var responseBody = await response.Content.ReadAsStringAsync();
        var parsedJson = JsonDocument.Parse(responseBody);
        return parsedJson.RootElement;
    }
}
