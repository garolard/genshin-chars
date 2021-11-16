using System.Collections.Generic;
using System.Threading.Tasks;
using GenshinBuilder.Core.Models;

namespace GenshinBuilder.Core.Services
{
    public interface IHttpCharacterRepository
    {
        Task<IEnumerable<Character>> FindAll();
    }
}