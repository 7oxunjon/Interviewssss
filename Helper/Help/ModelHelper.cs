using DATA.DTO;
using DATA.Model;
using Newtonsoft.Json;
using System.Net.WebSockets;
using System.Text;

namespace Helper.Help
{
    public class ModelHelper
    {
        protected readonly HttpClient client;
        protected readonly string uri;

        public ModelHelper(HttpClient client, string uri)
        {
            this.client = new HttpClient();
            this.uri = uri;
        }

        public async Task<List<SuhbatOluvchi>> GetAll()
        {
            var respons = await client.GetAsync(uri);
            if (respons.IsSuccessStatusCode)
            {
                var con = await respons.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<SuhbatOluvchi>>(con);
                return data;
            }
            else return null;
        }

        public async Task<string> Insert(SuhbatOluvchiDTO dTO)
        {
            var json = JsonConvert.SerializeObject(dTO);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var respons = await client.PostAsync(uri, data);
            return respons.ReasonPhrase;
        }
    }
}
