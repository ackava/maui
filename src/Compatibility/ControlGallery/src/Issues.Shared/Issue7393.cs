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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls.CustomAttributes;
using Microsoft.Maui.Controls.Internals;

#if UITEST
using Microsoft.Maui.Controls.Compatibility.UITests;
using Xamarin.UITest;
using NUnit.Framework;
#endif

namespace Microsoft.Maui.Controls.ControlGallery.Issues
{
	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.Github, 7393, "[Bug] CollectionView problems and crashes with IsGrouped=\"true\"",
		PlatformAffected.iOS)]
	public class Issue7393 : TestContentPage
	{
		ObservableCollection<_7393Group> _source;
		Label _result;

		const string Success = "Success";

		protected override void Init()
		{
			var cv = new CollectionView();

			_source = new ObservableCollection<_7393Group>();

			cv.GroupHeaderTemplate = new DataTemplate(() =>
			{
				var label = new Label();

				label.SetBinding(Label.TextProperty, new Binding("Header"));

				return label;
			});

			cv.GroupFooterTemplate = new DataTemplate(() =>
			{
				var label = new Label();

				label.SetBinding(Label.TextProperty, new Binding("Footer"));

				return label;
			});

			cv.ItemTemplate = new DataTemplate(() =>
			{
				var label = new Label();

				label.SetBinding(Label.TextProperty, new Binding("Name"));

				return label;
			});

			cv.ItemsSource = _source;
			cv.IsGrouped = true;

			_result = new Label { Text = "Waiting..." };

			var layout = new StackLayout();
			layout.Children.Add(_result);
			layout.Children.Add(cv);

			Content = layout;

			Appearing += Issue7393Appearing;
		}

		async void Issue7393Appearing(object sender, EventArgs e)
		{
			await AddItems();
			_result.Text = Success;
		}

		async Task AddItems()
		{
			var groupIndex = _source.Count + 1;

			if (groupIndex > 2)
			{
				return;
			}

			await Task.Delay(1000);

			var group = new _7393Group { Header = $"{groupIndex} Header (added)", Footer = $"{groupIndex} Footer (added)" };

			for (int itemIndex = 0; itemIndex < 3; itemIndex++)
			{
				var item = new _7393Item { Name = $"{groupIndex}.{itemIndex} Item (added)" };
				group.Add(item);
			}

			_source.Add(group);

			await AddItems();
		}

		class _7393Item
		{
			public string Name { get; set; }
		}

		class _7393Group : ObservableCollection<_7393Item>
		{
			public string Header { get; set; }
			public string Footer { get; set; }
		}

#if UITEST
		[Category(UITestCategories.CollectionView)]
		[Test]
		public void AddingItemsToGroupedCollectionViewShouldNotCrash()
		{
			RunningApp.WaitForElement(Success, timeout: TimeSpan.FromSeconds(30));
		}
#endif
	}
}
