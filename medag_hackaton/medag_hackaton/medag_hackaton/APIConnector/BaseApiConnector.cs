using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace medag_hackaton.APIConnector
{
    public abstract class BaseApiConnector<TKey, TEntity> : IApiConnector<TKey, TEntity>
    {
        public Uri Uri { get; set; }
        public string Url { get; set; }

        public BaseApiConnector(string url)
        {
            Url = url;
        }
        public async Task<TEntity> Get(TKey id)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri = new Uri($"{Url}{id}");
                HttpResponseMessage message = await client.GetAsync(Uri);
                return JsonConvert.DeserializeObject<TEntity>(await message.Content.ReadAsStringAsync());
            }
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            using (HttpClient client = new HttpClient())
            {
                Uri = new Uri($"{Url}");
                HttpResponseMessage message = await client.GetAsync(Uri);
                return JsonConvert.DeserializeObject<IEnumerable<TEntity>>(await message.Content.ReadAsStringAsync());
            }
        }

        public async Task<TKey> Insert(TEntity entity)
        {
            using (HttpClient client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(entity);
                HttpContent httpContent = new StringContent(json);
                Uri = new Uri($"{Url}");
                HttpResponseMessage message = await client.PostAsync(Uri,httpContent);

                return Convert(await message.Content.ReadAsStringAsync());
            }
        }

        public abstract TKey Convert(string json);
    }
}
