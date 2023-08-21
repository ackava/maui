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

using System.Collections.Generic;
using Microsoft.Maui.Controls.CustomAttributes;
using Microsoft.Maui.Controls.Internals;

#if UITEST
using Microsoft.Maui.Controls.Compatibility.UITests;
using Xamarin.UITest;
using NUnit.Framework;
#endif

namespace Microsoft.Maui.Controls.ControlGallery.Issues
{
#if UITEST
	[NUnit.Framework.Category(Compatibility.UITests.UITestCategories.Github5000)]
	[Category(UITestCategories.ListView)]
#endif

	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.Github, 2929, "[UWP] ListView with null ItemsSource crashes on 3.0.0.530893",
		PlatformAffected.UWP)]
	public class Issue2929 : TestContentPage
	{
		const string Success = "Success";

		protected override void Init()
		{
			var lv = new ListView();

			var instructions = new Label { Text = $"If the '{Success}' label is visible, this test has passed." };

			Content = new StackLayout
			{
				Children =
				{
					instructions,
					new Label { Text = Success },
					lv
				}
			};
		}

#if UITEST
		[Test]
		[Compatibility.UITests.FailsOnMauiIOS]
		public void NullItemSourceDoesNotCrash()
		{
			// If we can see the Success label, it means we didn't crash. 
			RunningApp.WaitForElement(Success);
		}
#endif
	}

#if UITEST
	[Category(UITestCategories.ListView)]
#endif

	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.None, 99, "Make sure setting ItemSource to null doesn't blow up",
		PlatformAffected.UWP)]
	public class SetListViewItemSourceToNull : TestContentPage
	{
		const string Success = "Success";
		const string Go = "Go";

		protected override void Init()
		{
			var lv = new ListView();
			var itemSource = new List<string>
			{
				"One",
				"Two",
				"Three"
			};
			lv.ItemsSource = itemSource;

			var result = new Label();

			var button = new Button { Text = Go };

			button.Clicked += (sender, args) =>
			{
				lv.ItemsSource = null;
				result.Text = Success;
			};

			var instructions = new Label
			{
				Text = $"Tap the '{Go}' button. If the '{Success}' label is visible, this test has passed."
			};

			Content = new StackLayout
			{
				Children =
				{
					instructions,
					button,
					result,
					lv
				}
			};
		}

#if UITEST
		[Test]
		[NUnit.Framework.Category(UITestCategories.ListView)]
		[Compatibility.UITests.FailsOnMauiIOS]
		public void SettingItemsSourceToNullDoesNotCrash()
		{
			RunningApp.WaitForElement(Go);
			RunningApp.Tap(Go);

			// If we can see the Success label, it means we didn't crash. 
			RunningApp.WaitForElement(Success);
		}
#endif
	}
}