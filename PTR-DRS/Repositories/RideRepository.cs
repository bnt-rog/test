using Newtonsoft.Json;
using PTR_DRS.Models;
using PTR_DRS.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PTR_DRS.Repositories
{
    public class RideRepository
    {
        public static async Task<List<Ride>> GetRides()
        {
            using (HttpClient client = await PTRDRSHttpClient.GetClient())
            {
                var url = client.BaseAddress + "rides";
                String json = await client.GetStringAsync(url);

                var rides = JsonConvert.DeserializeObject<List<Ride>>(json);

                return rides;
            }
        }

        public static async void InsertRide(Ride ride)
        {
            using (HttpClient client = await PTRDRSHttpClient.GetClient())
            {
                var url = client.BaseAddress + "ride";
                try
                {
                    ride.Id = Guid.NewGuid();
                    string json = JsonConvert.SerializeObject(ride);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    await client.PostAsync(url, content);
                }
                catch (Exception ex)
                {
                    throw ex.InnerException;
                }
            }
        }
    }
}
