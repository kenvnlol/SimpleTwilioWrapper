using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TwilioConversations.ResponseModels;

namespace TwilioConversations.Resources;

public class ConversationResource
{
    [JsonPropertyName("unique_name")]
    public required string UniqueName { get; init; }

    [JsonPropertyName("unique_name")]
    public required string DateUpdated { get; init; }

    [JsonPropertyName("unique_name")]
    public required string FriendlyName { get; init; }

    [JsonPropertyName("unique_name")]
    public required string AccountSid { get; init; }

    [JsonPropertyName("unique_name")]
    public required string DateCreated { get; init; }

    [JsonPropertyName("unique_name")]
    public required string Sid { get; init; }

    [JsonPropertyName("meta")]
    public required Meta Meta { get; init; }

    [JsonPropertyName("messages")]
    public HashSet<MessageResource> Messages { get; } = new HashSet<MessageResource>();
}
