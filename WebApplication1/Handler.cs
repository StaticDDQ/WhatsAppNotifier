using Microsoft.AspNet.WebHooks;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace MessagingTest
{
    public class Handler : WebHookHandler
    {
        public override Task ExecuteAsync(string receiver, WebHookHandlerContext context)
        {
            string action = context.Actions.First();
            JObject data = context.GetDataOrDefault<JObject>();

            Debug.WriteLine(action);

            return Task.FromResult(true);
        }
    }
}