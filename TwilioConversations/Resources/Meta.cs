using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwilioConversations.Resources;

public class Meta
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public required string FirstPageUrl { get; set; }

    public string? PreviousPageUrl { get; set; }

    public string? NextPageUrl { get; set; } 
}

