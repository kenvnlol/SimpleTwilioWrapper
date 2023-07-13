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

        var response = await _client.MakeHttpRequest<ConversationResource>(HttpMethod.Post, content);

        // Should never be null when a conversation is first created.
        return response.Sid!;
    }

  
    public async Task<ConversationResource> GetConversation(string conversationSid, int pageSize = 25, string? pageToken = null)
        => await _client.MakeHttpRequest<ConversationResource>(HttpMethod.Get, uri: UrlHelper.GetConversationsUri(conversationSid, pageSize, pageToken));



    public async Task AddParticipants(string conversationSid, string identity)
    {
        var content = new FormUrlEncodedContent(new Dictionary<string, string> { { "Identity", identity} });

        var response = await _client.PostAsync(UrlHelper.AddParticipantsUri(conversationSid), content: content);

        response.EnsureSuccessStatusCode();
    }

    public async Task SendMessage(string conversationSid, string body, string author)
    {
        var content = new FormUrlEncodedContent(new Dictionary<string, string> { { "Body", body }, { "Author", author } });

        var response = await _client.PostAsync(UrlHelper.PostMessageUri(conversationSid), content: content);

        response.EnsureSuccessStatusCode();
    }
}
