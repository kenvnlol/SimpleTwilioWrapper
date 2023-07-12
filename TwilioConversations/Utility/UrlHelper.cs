using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwilioConversations.Utility;

public static class UrlHelper
{
    public const string BaseUri = "https://conversations.twilio.com/v1/Conversations/";


    public static string GetConversationUri(string conversationSid)
        => $"{conversationSid}";

    public static string AddParticipantsUri(string conversationSid)
        => $"{conversationSid}/Participants";

    public static string GetConversationsUri(string conversationSid, int pageSize, string? pageToken = null)
    {
        string uri = $"{conversationSid}/Messages?PageSize={pageSize}";

        if (!string.IsNullOrEmpty(pageToken))
        {
            uri += $"&PageToken={pageToken}";
        }

        return uri;
    }

    public static string PostMessageUri(string conversationSid)
        => $"{conversationSid}/Messages";
}
