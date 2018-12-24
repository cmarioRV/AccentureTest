using Foundation;
using System;
using UIKit;
using SDWebImage;

namespace MyBook.iOS.Views
{
    public partial class BookCell : UITableViewCell
    {
        public BookCell (IntPtr handle) : base (handle)
        {
        }

        public void Configure(Item item)
        {
            titleLabel.Text = item.Title;
            subtitleLabel.Text = item.Subtitle;
            bookImageView.SetImage(new NSUrl(item.Image), UIImage.FromBundle("Book"));
        }
    }
}