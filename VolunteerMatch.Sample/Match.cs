using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using VolunteerMatch.Sample.Models;

namespace VolunteerMatch.Sample
{
    public class Match
    {
        public Match()
        {
            this.Username = ConfigurationManager.AppSettings["vmUsername"];
            this.ApiKey = ConfigurationManager.AppSettings["vmApiKey"];
            this.DateFormat = ConfigurationManager.AppSettings["vmDateFormat"];
        }

        public async Task<OpportunityResult> Find(string location)
        {
            var query = $"{{\"location\":\"{location}\",\"numberOfResults\":3}}";

            var client = new HttpClient();
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, $"http://www.volunteermatch.org/api/call?action={this.Action}&query={query}");
            var response = await client.SendAsync(requestMessage);
            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<OpportunityResult>(content);

            return result;
        }

        private string Action { get { return "searchOpportunities"; } }    
        private string Username { get; set; }
        private string ApiKey { get; set; }
        private string DateFormat { get; set; }
        private DateTime Created { get; set; }

        private string PasswordDigest
        {
            get
            {
                string created = DateTime.Now.ToString();
                string passwordDigest = $"{this.Nonce}{this.Created.ToString(this.DateFormat)}{this.ApiKey}";

                byte[] intermediateBytes = Encoding.UTF8.GetBytes(passwordDigest);
                byte[] hash = SHA256.Create().ComputeHash(intermediateBytes);
                return Convert.ToBase64String(hash, Base64FormattingOptions.None);
            }
        }

        string _nonce;
        private string Nonce
        {
            get
            {
                if (String.IsNullOrWhiteSpace(this._nonce))
                {
                    RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
                    byte[] bytes = new byte[20];
                    provider.GetBytes(bytes);
                    this._nonce = System.Convert.ToBase64String(bytes);
                }

                return this._nonce;
            }
        }
    }
}