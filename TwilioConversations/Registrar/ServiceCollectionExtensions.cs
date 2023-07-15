using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TwilioConversations.Utility;

namespace TwilioConversations.Registrar;

public static class ServiceCollectionExtensions
{
    public static void AddTwilioWrapper(this IServiceCollection services, string accountSid, string authToken)
    {
        var basicAuth = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{accountSid}:{authToken}"));

        services.AddHttpClient(HttpClientNames.TwilioConversation, c =>
        {
            c.BaseAddress = new Uri(UrlHelper.BaseUri);
            c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", basicAuth);
            c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            c.DefaultRequestHeaders.Add("X-Twilio-Webhook-Enabled", "true");
        });

        services.AddScoped<ConversationClient>();
    }
}
