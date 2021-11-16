using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GenshinBuilder.Core.Models;
using Newtonsoft.Json;

namespace GenshinBuilder.Core.Services.Impl
{
    public class HttpCharacterRepository : IHttpCharacterRepository
    {
        private readonly HttpClient _client;

        public HttpCharacterRepository(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Character>> FindAll()
        {
            var res = await _client.GetStringAsync("https://api.genshin.dev/characters/all");
            return JsonConvert.DeserializeObject<IList<Character>>(res);
        }
    }
}