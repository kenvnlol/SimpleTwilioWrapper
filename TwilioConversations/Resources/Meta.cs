using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TwilioConversations.Resources;

public class Meta
{
    [JsonPropertyName("page")]
    public int Page { get; set; }

    [JsonPropertyName("page_size")]
    public int PageSize { get; set; }

    [JsonPropertyName("first_page_url")]
    public required string FirstPageUrl { get; set; }

    [JsonPropertyName("previous_page_url")]
    public string? PreviousPageUrl { get; set; }

    [JsonPropertyName("next_page_url")]
    public string? NextPageUrl { get; set; }
}

