using System;
using System.Collections.Specialized;
using System.Linq;
using Foundation;
using MyBook.iOS.Views;
using UIKit;

namespace MyBook.iOS.ViewControllers
{
    public partial class BrowseViewController : UITableViewController
    {
        UIRefreshControl refreshControl;
        UISearchController search;

        public ItemsViewModel ViewModel { get; set; }

        public BrowseViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            ViewModel = new ItemsViewModel();

            refreshControl = new UIRefreshControl();
            refreshControl.ValueChanged += RefreshControl_ValueChanged;
            TableView.Add(refreshControl);
            TableView.Source = new ItemsDataSource(ViewModel);

            Title = ViewModel.Title;

            ViewModel.PropertyChanged += IsBusy_PropertyChanged;
            ViewModel.Items.CollectionChanged += Items_CollectionChanged;

            search = new UISearchController(searchResultsController: null)
            {
                DimsBackgroundDuringPresentation = false
            };

            search.SearchResultsUpdater = this;
            DefinesPresentationContext = true;

            NavigationItem.SearchController = search;
        }

        public override void ViewWillLayoutSubviews()
        {
            base.ViewWillLayoutSubviews();

            using (var searchKey = new NSString("searchField"))
            {
                var textField = (UITextField)search.SearchBar.ValueForKey(searchKey);
                textField.TextColor = UIColor.White;
            }
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier == "NavigateToItemDetailSegue")
            {
                var controller = segue.DestinationViewController as BrowseItemDetailViewController;
                var indexPath = TableView.IndexPathForCell(sender as UITableViewCell);
                var item = ViewModel.Items[indexPath.Row];

                controller.ViewModel = new ItemDetailViewModel(item);
            }
        }

        void RefreshControl_ValueChanged(object sender, EventArgs e)
        {
            if (!ViewModel.IsBusy && refreshControl.Refreshing)
                ViewModel.LoadItemsCommand.Execute(search.SearchBar.Text);
        }

        void IsBusy_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var propertyName = e.PropertyName;
            switch (propertyName)
            {
                case nameof(ViewModel.IsBusy):
                    {
                        InvokeOnMainThread(() =>
                        {
                            if (ViewModel.IsBusy && !refreshControl.Refreshing)
                                refreshControl.BeginRefreshing();
                            else if (!ViewModel.IsBusy)
                                refreshControl.EndRefreshing();
                        });
                    }
                    break;
            }
        }

        void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            InvokeOnMainThread(() => TableView.ReloadData());
        }
    }

    class ItemsDataSource : UITableViewSource
    {
        static readonly NSString CELL_IDENTIFIER = new NSString("BOOK_CELL");

        ItemsViewModel viewModel;

        public ItemsDataSource(ItemsViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return viewModel.Items.Count;
        }
        public override nint NumberOfSections(UITableView tableView) => 1;

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            BookCell cell = tableView.DequeueReusableCell(CELL_IDENTIFIER, indexPath) as BookCell;

            var item = viewModel.Items[indexPath.Row];
            cell.Configure(item);
            cell.LayoutMargins = UIEdgeInsets.Zero;

            return cell;
        }
    }
}
