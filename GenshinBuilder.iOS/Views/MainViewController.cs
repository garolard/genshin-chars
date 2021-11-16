using Foundation;
using GenshinBuilder.Core.ViewModels;
using GenshinBuilder.iOS.Controls;
using MvvmCross.Platforms.Ios.Views;
using UIKit;

namespace GenshinBuilder.iOS.Views
{
    [Register(nameof(MainViewController))]
    public class MainViewController : MvxTableViewController<MainViewModel>
    {
        public MainViewController() : base()
        {
            this.Title = "Genshin Chars";
        }
        
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var source = new MyTableViewSource(TableView, UITableViewCellStyle.Default, new NSString("MyCell"), "",
                UITableViewCellAccessory.None);
            TableView.RegisterClassForCellReuse(typeof(MyCell), new NSString(nameof(MyCell)));
            TableView.Source = source;
            TableView.ReloadData();

            var set = CreateBindingSet();
            set.Bind(source).To(vm => vm.Characters);
            set.Apply();

        }
    }
}