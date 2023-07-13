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
    // Might want to create a switch for different verbs instead of ternary
    public static async Task<T> MakeHttpRequest<T>(this HttpClient client, HttpMethod method, HttpContent? content = null, string? uri = null)
    {
        var response = method == HttpMethod.Get ? await client.GetAsync(uri) : await client.PostAsync(uri, content);

        response.EnsureSuccessStatusCode();

        T deserialized;
        using (var stream = await response.Content.ReadAsStreamAsync())
        {
            deserialized = await JsonSerializer.DeserializeAsync<T>(stream) ?? throw new InvalidOperationException("Failed to deserialize response.");
        }

        return deserialized;
    }
}
