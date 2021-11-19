using System.Collections.Generic;
using System.Linq;
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
            var idsStr = await _client.GetStringAsync("https://api.genshin.dev/characters");

            var characters = JsonConvert.DeserializeObject<IList<Character>>(res);
            var ids = JsonConvert.DeserializeObject<string[]>(idsStr);

            return ids.Zip(characters, (id, character) =>
            {
                character.Id = id;
                return character;
            });
        }
    }
}