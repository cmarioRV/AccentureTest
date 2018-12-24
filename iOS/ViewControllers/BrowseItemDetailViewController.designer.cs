// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace MyBook.iOS.ViewControllers
{
    [Register ("ItemDetailViewController")]
    partial class BrowseItemDetailViewController
    {
        [Outlet]
        UIKit.UIImageView BookImage { get; set; }


        [Outlet]
        UIKit.UILabel BookISBNLabel { get; set; }


        [Outlet]
        UIKit.UILabel BookPriceLabel { get; set; }


        [Outlet]
        UIKit.UILabel BookSubtitleLabel { get; set; }


        [Outlet]
        UIKit.UILabel BookTitleLabel { get; set; }


        [Outlet]
        UIKit.UILabel BookUrlLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (BookImage != null) {
                BookImage.Dispose ();
                BookImage = null;
            }

            if (BookISBNLabel != null) {
                BookISBNLabel.Dispose ();
                BookISBNLabel = null;
            }

            if (BookPriceLabel != null) {
                BookPriceLabel.Dispose ();
                BookPriceLabel = null;
            }

            if (BookSubtitleLabel != null) {
                BookSubtitleLabel.Dispose ();
                BookSubtitleLabel = null;
            }

            if (BookTitleLabel != null) {
                BookTitleLabel.Dispose ();
                BookTitleLabel = null;
            }

            if (BookUrlLabel != null) {
                BookUrlLabel.Dispose ();
                BookUrlLabel = null;
            }
        }
    }
}