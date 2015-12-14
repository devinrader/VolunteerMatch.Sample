using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Twilio.TwiML;
using Twilio.TwiML.Mvc;

namespace VolunteerMatch.Sample.Controllers
{
    public class HomeController : TwilioController
    {
        // GET: Home
        public async Task<ActionResult> Index(string To, string From, string Body)
        {
            var response = new TwilioResponse();

            var match = new Match();
            var opportunityResult = await match.Find(Body);

            var builder = new StringBuilder();
            foreach (var opportunity in opportunityResult.Opportunities)
            {
                builder.Append($"{opportunity.Title}\r\n");
            }

            response.Message(builder.ToString());
            return TwiML(response);
        }
    }
}