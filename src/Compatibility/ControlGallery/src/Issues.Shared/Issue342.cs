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
using System.Linq;
using Microsoft.Maui.Controls.CustomAttributes;
using Microsoft.Maui.Controls.Internals;

#if UITEST
using NUnit.Framework;
using Xamarin.UITest;
using Microsoft.Maui.Controls.Compatibility.UITests;
#endif

namespace Microsoft.Maui.Controls.ControlGallery.Issues
{
	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.Github, 342, "NRE when Image is not assigned source", PlatformAffected.WinPhone)]
	public class Issue342NoSource : TestContentPage
	{
		protected override void Init()
		{
			Title = "Issue 342";
			Content = new StackLayout
			{
				Children = {
					new Label {
						Text = "Uninitialized image"
					},
					new Image ()
				}
			};
		}

		// Should not throw exception when user does not include image

#if UITEST
		[Test]
		[Compatibility.UITests.FailsOnMauiIOS]
		public void Issue342NoSourceTestsLablePresentNoImage()
		{
			RunningApp.WaitForElement(q => q.Marked("Uninitialized image"), "Cannot see label");
			RunningApp.Screenshot("All elements present");
		}
#endif
	}

	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.Github, 342, "NRE when Image is delayed source", PlatformAffected.WinPhone)]
	public class Issue342DelayedSource : TestContentPage
	{
		protected override void Init()
		{
			Title = "Issue 342";

			_image = new Image();

			Content = new StackLayout
			{
				AutomationId = "TestReady",
				Children = {
					new Label {
						Text = "Delayed image"
					},
					_image
				}
			};

			AddSourceAfterDelay();
		}

		// Should not throw exception when user does not include image
		Image _image;

		void AddSourceAfterDelay()
		{
			Device.StartTimer(TimeSpan.FromSeconds(2), () =>
			{
				_image.Source = "cover1.jpg";
				return false;
			});
		}

#if UITEST
		[Test]
		[Category(UITestCategories.ManualReview)]
		[Compatibility.UITests.FailsOnMauiIOS]
		public void Issue342DelayedLoadTestsImageLoads()
		{
			RunningApp.WaitForElement("TestReady");
			RunningApp.Screenshot("Should not crash");
		}
#endif
	}
}
