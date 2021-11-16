using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using GenshinBuilder.Core.Models;
using GenshinBuilder.Core.Services;
using MvvmCross.Commands;
using MvvmCross.ViewModels;

namespace GenshinBuilder.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private readonly IHttpCharacterRepository _repo;

        public MainViewModel(IHttpCharacterRepository repo)
        {
            _repo = repo;
        }

        public override async Task Initialize()
        {
            await base.Initialize();
            _characters = new ObservableCollection<Character>();
            InitCommand.Execute(null);
        }

        private ObservableCollection<Character> _characters;
        public ObservableCollection<Character> Characters
        {
            get => _characters;
            set => SetProperty(ref _characters, value);
        }

        public ICommand InitCommand => new MvxAsyncCommand(async () =>
        {
            var chars = await _repo.FindAll();
            Characters.Clear();
            foreach (var c in chars)
            {
                Characters.Add(c);
            }
        });
    }
}