using System;
using UIKit;
using SDWebImage;
using Foundation;

namespace MyBook.iOS.ViewControllers
{
    public partial class BrowseItemDetailViewController : UIViewController
    {
        public ItemDetailViewModel ViewModel { get; set; }
        public BrowseItemDetailViewController(IntPtr handle) : base(handle) { }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = ViewModel.Title;

            BookTitleLabel.Text = ViewModel.Item.Title;
            BookSubtitleLabel.Text = ViewModel.Item.Subtitle;
            BookISBNLabel.Text = $"ISBN: {ViewModel.Item.Isbn13}";
            BookUrlLabel.Text = ViewModel.Item.Url;
            BookPriceLabel.Text = $"Precio: {ViewModel.Item.Price}";
            BookImage.SetImage(new NSUrl(ViewModel.Item.Image), UIImage.FromBundle("Book"));
        }
    }
}
