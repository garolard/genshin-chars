using System.Net.Http;
using GenshinBuilder.Core.Services;
using GenshinBuilder.Core.Services.Impl;
using GenshinBuilder.Core.ViewModels;
using MvvmCross;
using MvvmCross.ViewModels;

namespace GenshinBuilder.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.IoCProvider.RegisterSingleton(new HttpClient());
            
            Mvx.IoCProvider.RegisterType<IHttpCharacterRepository, HttpCharacterRepository>();
            
            RegisterAppStart<MainViewModel>();
        }
    }
}