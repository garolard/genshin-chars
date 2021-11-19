using GenshinBuilder.Core.Models;
using MvvmCross.ViewModels;

namespace GenshinBuilder.Core.ViewModels
{
    public class CharacterDetailViewModel : MvxViewModel<Character>
    {
        private Character _character;

        public override void Prepare(Character character)
        {
            _character = character;
        }

        public string Name => _character.Name;
        public string Nation => _character.Nation;
        public string Affiliation => _character.Affiliation;
    }
}