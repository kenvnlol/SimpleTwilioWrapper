using System.Text;
using System.Text.Json;
using TwilioConversations.ResponseModels;
using TwilioConversations.Utility;

namespace TwilioConversations;


public class TwilioConversations
{
    private readonly IHttpClientFactory _factory;
    private readonly HttpClient _client;
    public TwilioConversations(IHttpClientFactory factory)
    {
        _factory = factory;
        _client = _factory.CreateClient(HttpClientNames.TwilioConversation);
    }

    public async Task<string> CreateConversation(string? friendlyName = null)
    {
        var content = CreateFormUrlEncodedContent("FriendlyName", friendlyName ?? string.Empty);

        var response = await _client.SendHttpRequestAsync(HttpMethod.Post, content);

        var jsonResponse = await response.GetContentAsJsonElementAsync();

        return jsonResponse.GetProperty("sid").ToString();
    }

  
    public async Task<IEnumerable<MessageResource>> GetConversation(string conversationSid, int pageSize = 25, string? pageToken = null)
    {
        var response = await _client.SendHttpRequestAsync(HttpMethod.Get, uri : UrlHelper.GetConversationsUri(conversationSid, pageSize, pageToken));

        var jsonResponse = await response.GetContentAsJsonElementAsync();

        var messages = JsonSerializer.Deserialize<IEnumerable<MessageResource>>(jsonResponse.GetProperty("messages"));

        return messages ?? Enumerable.Empty<MessageResource>();
    }

    public async Task AddParticipants(string conversationSid, string identity)
    {
        var content = CreateFormUrlEncodedContent(new Dictionary<string, string> { { "Identity", identity} });

        await _client.SendHttpRequestAsync(HttpMethod.Post, content: content, uri: UrlHelper.AddParticipantsUri(conversationSid));
    }

    public async Task SendMessage(string conversationSid, string body, string author)
    {
        var content = CreateFormUrlEncodedContent(new Dictionary<string, string> { { "Body", body }, { "Author", author } });

        await _client.SendHttpRequestAsync(HttpMethod.Post, content: content, uri: UrlHelper.PostMessageUri(conversationSid));
    }

    private static StringContent CreateFormUrlEncodedContent(string key, string value)
    {
        return new StringContent($"{key}={value}", Encoding.UTF8);
    }

    private static HttpContent CreateFormUrlEncodedContent(Dictionary<string, string> data)
    {
        return new FormUrlEncodedContent(data);
    }
}
