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

using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using ObjCRuntime;
using UIKit;

namespace Microsoft.Maui.Controls.Compatibility.Platform.iOS
{
	internal static class ItemsSourceFactory
	{
		public static IItemsViewSource Create(IEnumerable itemsSource, UICollectionViewController collectionViewController)
		{
			if (itemsSource == null)
			{
				return new EmptySource();
			}

			switch (itemsSource)
			{
				case IList _ when itemsSource is INotifyCollectionChanged:
					return new ObservableItemsSource(itemsSource as IList, collectionViewController);
				case IEnumerable _ when itemsSource is INotifyCollectionChanged:
					return new ObservableItemsSource(itemsSource as IEnumerable, collectionViewController);
				case IEnumerable<object> generic:
					return new ListSource(generic);
			}

			return new ListSource(itemsSource);
		}

		public static IItemsViewSource CreateGrouped(IEnumerable itemsSource, UICollectionViewController collectionViewController)
		{
			if (itemsSource == null)
			{
				return new EmptySource();
			}

			return new ObservableGroupedSource(itemsSource, collectionViewController);
		}

		public static ILoopItemsViewSource CreateForCarouselView(IEnumerable itemsSource, UICollectionViewController collectionViewController, bool loop)
		{
			if (itemsSource == null)
			{
				return new EmptySource();
			}

			switch (itemsSource)
			{
				case IList _ when itemsSource is INotifyCollectionChanged:
					return new LoopObservableItemsSource(itemsSource as IList, collectionViewController, loop);
				case IEnumerable _ when itemsSource is INotifyCollectionChanged:
					return new LoopObservableItemsSource(itemsSource as IEnumerable, collectionViewController, loop);
				case IEnumerable<object> generic:
					return new LoopListSource(generic, loop);
			}

			return new LoopListSource(itemsSource, loop);
		}

	}
}