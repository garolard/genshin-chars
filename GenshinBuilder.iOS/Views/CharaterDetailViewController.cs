using Cirrious.FluentLayouts.Touch;
using CoreGraphics;
using Foundation;
using GenshinBuilder.Core.ViewModels;
using MvvmCross.Platforms.Ios.Views;
using UIKit;

namespace GenshinBuilder.iOS.Views
{
    [Register(nameof(CharaterDetailViewController))]
    public class CharaterDetailViewController : MvxViewController<CharacterDetailViewModel>
    {
        private UILabel _name;
        private UILabel _nation;
        private UILabel _affiliation;
        
        public override void ViewDidLoad()
        {
            var scrollView = new UIScrollView()
            {
                BackgroundColor = UIColor.White,
                ShowsHorizontalScrollIndicator = false,
                AutoresizingMask = UIViewAutoresizing.FlexibleHeight,
            };
            View = scrollView;
            scrollView.TranslatesAutoresizingMaskIntoConstraints = true;

            base.ViewDidLoad();

            _name = new UILabel()
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                Font = UIFont.PreferredTitle1
            };

            _nation = new UILabel()
            {
                TranslatesAutoresizingMaskIntoConstraints = false
            };

            _affiliation = new UILabel()
            {
                TranslatesAutoresizingMaskIntoConstraints = false
            };

            View.AddSubviews(_name, _nation, _affiliation);


            var set = CreateBindingSet();
            set.Bind(Title).To(c => c.Name);
            set.Bind(_name).To(c => c.Name);
            set.Bind(_nation).To(c => c.Nation);
            set.Bind(_affiliation).To(c => c.Affiliation);
            set.Apply();

            var constraints = View.VerticalStackPanelConstraints(
                new Margins(20, 10, 20, 10, 5, 5),
                View.Subviews);
            View.AddConstraints(constraints);
        }
    }
}