using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TwilioConversations.Resources;

namespace TwilioConversations.Utility;

public static class HttpClientExtensions
{

    public static async Task<string> PostHttpRequest(this HttpClient client, HttpContent? content = null, string? uri = null)
    {
        var response = await client.PostAsync(uri, content);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }
    public static async Task<string> GetHttpRequest(this HttpClient client, HttpContent? content = null, string? uri = null) 
    {
        var response = await client.GetAsync(uri);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }
}
