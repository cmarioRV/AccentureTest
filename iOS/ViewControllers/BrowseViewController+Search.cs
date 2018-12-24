using System;
using System.Collections.ObjectModel;
using System.Linq;
using UIKit;

namespace MyBook.iOS.ViewControllers
{
    public partial class BrowseViewController : IUISearchResultsUpdating
    {
        public void UpdateSearchResultsForSearchController(UISearchController searchController)
        {
            var find = searchController.SearchBar.Text;
            if (!String.IsNullOrEmpty(find))
            {
                ViewModel.LoadItemsCommand.Execute(find);
                TableView.ReloadData();
            }
        }
    }
}

