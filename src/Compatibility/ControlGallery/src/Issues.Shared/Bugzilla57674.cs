﻿//using System;
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
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Microsoft.Maui.Controls.CustomAttributes;
using Microsoft.Maui.Controls.Internals;

#if UITEST
using Xamarin.UITest;
using NUnit.Framework;
#endif

namespace Microsoft.Maui.Controls.ControlGallery.Issues
{
#if UITEST
	[NUnit.Framework.Category(Compatibility.UITests.UITestCategories.Bugzilla)]
#endif
	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.Bugzilla, 57674, "ListView not honoring INotifyCollectionChanged ", PlatformAffected.UWP)]
	public class Bugzilla57674 : TestContentPage
	{
		MyCollection _myCollection;
		protected override void Init()
		{
			// Initialize ui here instead of ctor
			_myCollection = new MyCollection();

			var stackLayout = new StackLayout();
			var button = new Button
			{
				AutomationId = "IssueButton",
				Text = "Add new element to ListView"
			};
			button.Clicked += (object sender, EventArgs e) => _myCollection.AddNewItem();

			stackLayout.Children.Add(button);

			stackLayout.Children.Add(new ListView
			{
				AutomationId = "IssueListView",
				ItemsSource = _myCollection
			});

			Content = stackLayout;
		}

#if UITEST
		[Test]
		[Compatibility.UITests.FailsOnMauiIOS]
		public void Bugzilla57674Test()
		{
			RunningApp.Screenshot("Initial Status");
			RunningApp.WaitForElement(q => q.Marked("IssueListView"));
			RunningApp.Tap(a => a.Button("IssueButton"));
			RunningApp.Screenshot("Element Added to List");
		}
#endif
	}

	public class MyCollection : IEnumerable<string>, INotifyCollectionChanged
	{
		readonly List<string> _internalList = new List<string>();
		public MyCollection()
		{
		}

		public IEnumerable<string> GetItems()
		{
			foreach (var item in _internalList)
			{
				yield return item;
			}
		}

		public IEnumerator<string> GetEnumerator()
		{
			return GetItems().GetEnumerator();
		}

		public void AddNewItem()
		{
			int index = _internalList.Count;
			string item = Guid.NewGuid().ToString();
			_internalList.Add(item);
			OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, index));
		}

		public event NotifyCollectionChangedEventHandler CollectionChanged;

		protected void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
		{
			CollectionChanged?.Invoke(this, e);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
