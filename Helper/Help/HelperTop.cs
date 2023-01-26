using DATA.DTO;
using DATA.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Help
{
    public class HelperTop
    {
        protected readonly HttpClient client;
        protected readonly string Uri;

        public HelperTop(HttpClient client, string uri)
        {
            this.client = client;
            Uri = uri;
        }

         public async Task<List<SuhbatTopshiruvchi>> GetAll()
         {
            var respons = await client.GetAsync(Uri);
            if (respons.IsSuccessStatusCode)
            {
                var conn = await respons.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<SuhbatTopshiruvchi>>(conn);
                return data;
            }
            else return null;
         }
         
        public async Task<string> Insert(SuhbatTopshirivchiDTO topshirivchiDTO)
        {
            var json = JsonConvert.SerializeObject(topshirivchiDTO);
            var data = new StringContent(json, Encoding.UTF8,"application/json");
            var respons = await client.PostAsync(Uri, data);
            return respons?.ReasonPhrase;
        }

        public async Task<string>Update(int id, SuhbatTopshirivchiDTO dTO)
        {
            var json = JsonConvert.SerializeObject(dTO);
            var data = new StringContent(json,encoding: Encoding.UTF8,"application/json");
            var respons = await client.PutAsync(Uri + "/" + id.ToString(), data);
            return respons?.ReasonPhrase;

        }
        public async Task<string> Delete(int id)
        {
            var respons = await client.DeleteAsync(Uri + "/" + id);
            return respons?.ReasonPhrase;
        }
        

    } 
}
