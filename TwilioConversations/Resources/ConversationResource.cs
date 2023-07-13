using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace TwilioConversations.Resources;

public class ConversationResource
{
    [JsonPropertyName("unique_name")]
    public string? UniqueName { get; init; }

    [JsonPropertyName("date-updated")]
    public string? DateUpdated { get; init; }

    [JsonPropertyName("friendly_name")]
    public string? FriendlyName { get; init; }

    [JsonPropertyName("account_sid")]
    public string? AccountSid { get; init; }

    [JsonPropertyName("date_created")]
    public string? DateCreated { get; init; }

    [JsonPropertyName("sid")]
    public required string Sid { get; init; }

    [JsonPropertyName("meta")]
    public Meta? Meta { get; init; }

    [JsonPropertyName("messages")]
    public List<MessageResource> Messages { get; set; } = new List<MessageResource>();
}
