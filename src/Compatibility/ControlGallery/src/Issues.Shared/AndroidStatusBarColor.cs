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

namespace Microsoft.Maui.Controls.ControlGallery.Issues
{
	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.None, 5553226, "Set status bar color on Android", PlatformAffected.Android)]
	public class AndroidStatusBarColor : TestContentPage
	{
		public const string Message = "ChangeStatusBarToRed";

		protected override void Init()
		{
			var layout = new StackLayout
			{
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.Fill,
				Margin = new Thickness(100)
			};

			var instructions = new Label
			{
				Text =
					"Tapping the button below should change the status bar color to red. If the status bar does not change to red, the test has failed. (Ignore this test for pre-Lollipop devices.)"
			};

			var button = new Button { Text = "Change Status Bar Color" };

			button.Clicked += (sender, args) => { MessagingCenter.Send(this, Message); };

			layout.Children.Add(instructions);
			layout.Children.Add(button);

			Content = layout;
		}
	}
}