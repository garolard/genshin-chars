using System;
using System.Collections.Generic;
using Cirrious.FluentLayouts.Touch;
using CoreGraphics;
using FFImageLoading.Cross;
using Foundation;
using GenshinBuilder.Core.Models;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Bindings;
using MvvmCross.Platforms.Ios.Binding.Views;
using UIKit;

namespace GenshinBuilder.iOS.Controls
{
    [Register(nameof(MyCell))]
    public class MyCell : MvxTableViewCell
    {
        public MyCell()
        {
            CreateLayout();
            InitializeBinding();
        }

        public MyCell(IntPtr handle) : base(handle)
        {
            CreateLayout();
            InitializeBinding();
        }

        private UILabel name;
        private MvxCachedImageView icon;

        private void CreateLayout()
        {
            name = new UILabel()
            {
                Font = UIFont.PreferredTitle3,
                Lines = 0,
                LineBreakMode = UILineBreakMode.WordWrap
            };

            icon = new MvxCachedImageView
            {
                DownsampleWidth = 64
            };

            ContentView.AddSubviews(icon, name);
            ContentView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            ContentView.AddConstraints(
                icon.AtTopOf(ContentView, 4),
                icon.AtLeftOf(ContentView, 4),
                
                name.ToRightOf(icon, 4),
                name.WithSameCenterY(icon));
        }

        private void InitializeBinding()
        {
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<MyCell, Character>();
                set.Bind(name).To(vm => vm.Name);
                set.Bind(icon).For(i => i.ImagePath).To(vm => vm.Id).WithConversion("CharacterNameToIconUrl");
                set.Apply();
            });
        }
    }
    
    public class MyTableViewSource : MvxStandardTableViewSource
    {
        public static readonly NSString CellTemplate = new NSString(nameof(MyCell));
        
        public MyTableViewSource(UITableView tableView) : base(tableView)
        {
        }

        public MyTableViewSource(UITableView tableView, NSString cellIdentifier) : base(tableView, cellIdentifier)
        {
        }

        public MyTableViewSource(UITableView tableView, string bindingText) : base(tableView, bindingText)
        {
        }

        public MyTableViewSource(IntPtr handle) : base(handle)
        {
        }

        public MyTableViewSource(UITableView tableView, UITableViewCellStyle style, NSString cellIdentifier, string bindingText, UITableViewCellAccessory tableViewCellAccessory = UITableViewCellAccessory.None) : base(tableView, style, cellIdentifier, bindingText, tableViewCellAccessory)
        {
        }

        public MyTableViewSource(UITableView tableView, UITableViewCellStyle style, NSString cellIdentifier, IEnumerable<MvxBindingDescription> descriptions, UITableViewCellAccessory tableViewCellAccessory = UITableViewCellAccessory.None) : base(tableView, style, cellIdentifier, descriptions, tableViewCellAccessory)
        {
        }

        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return 72;
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            var cell = tableView.DequeueReusableCell(CellTemplate, indexPath);
            cell.SetNeedsLayout();
            return cell;
        }
    }
}