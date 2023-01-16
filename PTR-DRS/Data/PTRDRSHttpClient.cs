using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTR_DRS.Data
{
    public class PTRDRSHttpClient
    {
        public static async Task<HttpClient> GetClient()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            string url = "https://europe-west1.gcp.data.mongodb-api.com/app/ptr-drs-mkmyk/endpoint/";
            httpClient.BaseAddress = new Uri(url);
            return httpClient;
        }
    }
}
