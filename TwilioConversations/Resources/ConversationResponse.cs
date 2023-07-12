using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwilioConversations.ResponseModels;

namespace TwilioConversations.Resources;

public class ConversationResponse
{
    public required Meta Meta { get; init; }
    public HashSet<MessageResource> Messages { get; } = new HashSet<MessageResource>(); 
}
