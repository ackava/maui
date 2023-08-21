//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Android.App;
//using Android.Content;
//using Android.Content.PM;
//using Android.OS;
//using Android.Renderscripts;
//using Android.Runtime;
//using Android.Views;
//using Android.Widget;
//using Microsoft.Maui.Controls.ControlGallery.Issues;

using System;
using CoreGraphics;
using ObjCRuntime;
using UIKit;

namespace Microsoft.Maui.Controls.Compatibility.Platform.iOS
{
	[System.Obsolete]
	public class GroupableItemsViewDelegator<TItemsView, TViewController> : SelectableItemsViewDelegator<TItemsView, TViewController>
		where TItemsView : GroupableItemsView
		where TViewController : GroupableItemsViewController<TItemsView>
	{
		public GroupableItemsViewDelegator(ItemsViewLayout itemsViewLayout, TViewController itemsViewController)
			: base(itemsViewLayout, itemsViewController)
		{
		}

		public override CGSize GetReferenceSizeForHeader(UICollectionView collectionView, UICollectionViewLayout layout, nint section)
		{
			return ViewController.GetReferenceSizeForHeader(collectionView, layout, section);
		}

		public override CGSize GetReferenceSizeForFooter(UICollectionView collectionView, UICollectionViewLayout layout, nint section)
		{
			return ViewController.GetReferenceSizeForFooter(collectionView, layout, section);
		}

		public override void ScrollAnimationEnded(UIScrollView scrollView)
		{
			ViewController?.HandleScrollAnimationEnded();
		}

		public override UIEdgeInsets GetInsetForSection(UICollectionView collectionView, UICollectionViewLayout layout, nint section)
		{
			if (ItemsViewLayout == null)
			{
				return default;
			}

			return ViewController.GetInsetForSection(ItemsViewLayout, collectionView, section);
		}
	}
}