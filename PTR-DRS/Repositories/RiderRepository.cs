using Newtonsoft.Json;
using PTR_DRS.Models;
using PTR_DRS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PTR_DRS.Repositories
{
    public class RiderRepository
    {
        public static async Task<List<Rider>> GetRiders()
        {
            using (HttpClient client = await PTRDRSHttpClient.GetClient())
            {
                var url = client.BaseAddress + "riders";
                String json = await client.GetStringAsync(url);

                var riders = JsonConvert.DeserializeObject<List<Rider>>(json);

                return riders;
            }
        }

        public static async void InsertRider(Rider rider)
        {
            using (HttpClient client = await PTRDRSHttpClient.GetClient())
            {
                var url = client.BaseAddress + "rider";
                try
                {
                    rider.Id = Guid.NewGuid();
                    string json = JsonConvert.SerializeObject(rider);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    await client.PostAsync(url, content);
                }
                catch (Exception ex)
                {
                    throw ex.InnerException;
                }
            }
        }

        public static async void InsertRiderRide(List<Rider> selectedRiders, Ride ride)
        {
            using (HttpClient client = await PTRDRSHttpClient.GetClient())
            {
                if (selectedRiders != null)
                {
                    foreach (Rider rider in selectedRiders)
                    {
                        if (rider != null)
                        {
                            var url = client.BaseAddress + "rider" + $"?id_rider={rider.Id}&id_ride={ride.Id}";
                            string json = JsonConvert.SerializeObject(rider);
                            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                            await client.PutAsync(url, content);
                        }
                    }
                }
            }
        }
    }
}
