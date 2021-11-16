using System;
using System.Collections.Generic;
using CoreGraphics;
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

        private void CreateLayout()
        {
            Accessory = UITableViewCellAccessory.None;
            name = new UILabel(new CGRect(10, 0, 75, 40));
            name.AdjustsFontSizeToFitWidth = true;
            name.Font = name.Font.WithSize(10);
            ContentView.AddSubview(name);
        }

        private void InitializeBinding()
        {
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<MyCell, Character>();
                set.Bind(name).To(vm => vm.Name);
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

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            var cell = tableView.DequeueReusableCell(CellTemplate, indexPath);
            cell.SetNeedsLayout();
            return cell;
        }
    }
}