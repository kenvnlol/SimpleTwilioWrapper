using System.Text;
using System.Text.Json;
using TwilioConversations.Resources;
using TwilioConversations.Utility;

namespace TwilioConversations;


public class ConversationClient
{
    private readonly IHttpClientFactory _factory;
    private readonly HttpClient _client;
    public ConversationClient(IHttpClientFactory factory)
    {
        _factory = factory;
        _client = _factory.CreateClient(HttpClientNames.TwilioConversation);
    }

    public async Task<string> CreateConversation(string? friendlyName = null)
    {
        var content = new FormUrlEncodedContent(new Dictionary<string, string> { { "FriendlyName", friendlyName ?? string.Empty } });

        var response = await _client.PostHttpRequest(content);

        var deserialized = JsonSerializer.Deserialize<ConversationResource>(response);

        return deserialized?.Sid ?? throw new InvalidOperationException("Failed to deserialize response.");
    }

  
    public async Task<IEnumerable<MessageResource>> GetConversation(string conversationSid, int pageSize = 25, string? pageToken = null)
    {
        var response = await _client.GetHttpRequest(uri: UrlHelper.GetConversationsUri(conversationSid, pageSize, pageToken));

        var deserialized = JsonSerializer.Deserialize<ConversationResource>(response);

        return deserialized?.Messages ?? Enumerable.Empty<MessageResource>();
    }

    public async Task AddParticipants(string conversationSid, string identity)
    {
        var content = new FormUrlEncodedContent(new Dictionary<string, string> { { "Identity", identity} });

        await _client.PostHttpRequest(content: content, uri: UrlHelper.AddParticipantsUri(conversationSid));
    }

    public async Task SendMessage(string conversationSid, string body, string author)
    {
        var content = new FormUrlEncodedContent(new Dictionary<string, string> { { "Body", body }, { "Author", author } });

        await _client.PostHttpRequest(content: content, uri: UrlHelper.PostMessageUri(conversationSid));
    }


}
