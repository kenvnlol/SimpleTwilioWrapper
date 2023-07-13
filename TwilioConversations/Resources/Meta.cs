using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web;

namespace TwilioConversations.Resources;

public class Meta
{
    [JsonPropertyName("page")]
    public int Page { get; init; }

    [JsonPropertyName("page_size")]
    public int PageSize { get; init; }

    [JsonPropertyName("first_page_url")]
    public required string FirstPageUrl { get; init; }

    [JsonPropertyName("previous_page_url")]
    public string? PreviousPageUrl { get; init; }

    [JsonPropertyName("next_page_url")]
    public string? NextPageUrl { get; init; }

    public string? NextPageToken
    {
        get => NextPageUrl is null ? null : HttpUtility.ParseQueryString(NextPageUrl)["PageToken"];
    }
}

