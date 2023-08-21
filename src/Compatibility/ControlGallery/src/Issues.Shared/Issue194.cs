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

using Microsoft.Maui.Controls.CustomAttributes;
using Microsoft.Maui.Controls.Internals;
using Microsoft.Maui.Devices;

namespace Microsoft.Maui.Controls.ControlGallery.Issues
{
	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.Github, 194, "iOS tab edit has no done button to return", PlatformAffected.iOS)]
	public class Issue194 : TabbedPage
	{
		public Issue194()
		{
			Title = "Issue 194";

			var leavePageBtn = new Button
			{
				Text = "Leave"
			};

			// May have unexpected behavior but navigation page is needed to replicate the bug.
			leavePageBtn.Clicked += (s, e) => Navigation.PopModalAsync();

			var pageOne = new ContentPage
			{
				Title = "Page 1",
				Content = leavePageBtn
			};
			var pageTwo = new ContentPage
			{
				Title = "Page 2"
			};
			var pageThree = new ContentPage
			{
				Title = "Page 3"
			};
			var pageFour = new ContentPage
			{
				Title = "Page 4"
			};
			var pageFive = new ContentPage
			{
				Title = "Page 5"
			};
			var pageSix = new ContentPage
			{
				Title = "Page 6"
			};
			var pageSeven = new ContentPage
			{
				Title = "Page 7"
			};
			var pageEight = new ContentPage
			{
				Title = "Page 8"
			};
			var pageNine = new ContentPage
			{
				Title = "Page 9"
			};

			if (DeviceInfo.Platform == DevicePlatform.iOS)
			{
				// Create an overflow amount of tabs depending on device
				if (DeviceInfo.Idiom == DeviceIdiom.Tablet)
				{
					Children.Add(pageOne);
					Children.Add(pageTwo);
					Children.Add(pageThree);
					Children.Add(pageFour);
					Children.Add(pageFive);
					Children.Add(pageSix);
					Children.Add(pageSeven);
					Children.Add(pageEight);
					Children.Add(pageNine);
				}
				else
				{
					Children.Add(pageOne);
					Children.Add(pageTwo);
					Children.Add(pageThree);
					Children.Add(pageFour);
					Children.Add(pageFive);
					Children.Add(pageSix);
				}
			}
		}
	}
}
