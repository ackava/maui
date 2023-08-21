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
	[NUnit.Framework.Category(Compatibility.UITests.UITestCategories.TabbedPage)]
#endif
	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.Bugzilla, 52419, "[A] OnAppearing called for previous pages in a tab's navigation when switching active tabs", PlatformAffected.Android)]
	public class Bugzilla52419 : TestTabbedPage
	{
		protected override void Init()
		{
			var nav1 = new NavigationPage { Title = "Tab Page 1" };
			nav1.PushAsync(new Bugzilla52419Page1());
			var nav2 = new NavigationPage { Title = "Tab Page 2" };
			nav2.PushAsync(new Bugzilla52419Page2());
			Children.Add(nav1);
			Children.Add(nav2);
		}

#if UITEST

#if __ANDROID__
		[Test]
		[Compatibility.UITests.FailsOnMauiAndroid]
		public void Bugzilla52419Test()
		{
			RunningApp.WaitForElement(q => q.Marked("Push new page"));
			RunningApp.Tap(q => q.Marked("Push new page"));
			RunningApp.WaitForElement(q => q.Marked("Push new page"));
			RunningApp.Tap(q => q.Marked("Push new page"));
			RunningApp.WaitForElement(q => q.Marked("Push new page"));
			RunningApp.Tap(q => q.Marked("Push new page"));
			RunningApp.Tap(q => q.Marked("Tab Page 2"));
			RunningApp.Tap(q => q.Marked("Tab Page 1"));
			RunningApp.Tap(q => q.Marked("Tab Page 2"));
			RunningApp.Tap(q => q.Marked("Tab Page 1"));
			RunningApp.Back();
			RunningApp.WaitForElement(q => q.Marked("AppearanceLabel"));
			var label = RunningApp.Query(q => q.Marked("AppearanceLabel"))[0];
			Assert.AreEqual("Times Appeared: 2", label.Text);
		}
#endif

#endif
	}

	class Bugzilla52419Page1 : ContentPage
	{
		public Label _timesAppeared { get; set; }
		int _count;

		string _guid = Guid.NewGuid().ToString();
		public Bugzilla52419Page1()
		{
			_timesAppeared = new Label
			{
				Text = "Times Appeared: " + _count.ToString(),
				AutomationId = "AppearanceLabel"
			};
			Content = new StackLayout
			{
				Children =
					{
						new Label
						{
							Text = "Page Guid: " + _guid
						},
						_timesAppeared,
						new Label
						{
							Text = "Click the button a couple times, switch to the second tab, and then back to the first. The Appearing event (which increase the counter) should only occur for the visible first tab."
						},
						new Button
						{
							Text = "Push new page",
							Command = new Command(() => Navigation.PushAsync(new Bugzilla52419Page1()))
						}
					}
			};
			Appearing += OnAppearing;
		}

		void OnAppearing(object sender, EventArgs e)
		{
			_count++;
			_timesAppeared.Text = "Times Appeared: " + _count.ToString();
		}
	}

	class Bugzilla52419Page2 : ContentPage
	{
		public Bugzilla52419Page2()
		{
			Title = "Tab Page 2";
			Content = new StackLayout
			{
				Children =
				{
					new Label
					{
						Text = "Other content"
					}
				}
			};
		}
	}
}