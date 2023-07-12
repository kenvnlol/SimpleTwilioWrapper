using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TwilioConversations.Resources;

public class MessageResource
{
    [JsonPropertyName("account_sid")]
    public required string AccountSid { get; init; }

    [JsonPropertyName("conversation_sid")]
    public required string ConversationSid { get; init; }

    [JsonPropertyName("sid")]
    public required string Sid { get; init; }

    [JsonPropertyName("index")]
    public int? Index { get; init; }

    [JsonPropertyName("author")]
    public required string Author { get; init; }

    [JsonPropertyName("body")]
    public required string Body { get; init; }

    [JsonPropertyName("participant_sid")]
    public required string ParticipantSid { get; init; }

    [JsonPropertyName("date_created")]
    public DateTime? DateCreated { get; init; }

    [JsonPropertyName("date_updated")]
    public DateTime? DateUpdated { get; init; }
}
