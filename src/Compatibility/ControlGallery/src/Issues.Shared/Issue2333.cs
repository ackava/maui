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

using System.Diagnostics;

using Microsoft.Maui.Controls.CustomAttributes;
using Microsoft.Maui.Controls.Internals;

namespace Microsoft.Maui.Controls.ControlGallery.Issues
{
	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.Github, 2333, "TimePicker not shown when .Focus() is called", PlatformAffected.WinPhone)]
	public class Issue2333 : ContentPage
	{
		public Issue2333()
		{
			var timePicker = new TimePicker();
			var timePickerBtn = new Button
			{
				Text = "Click me to call .Focus on TimePicker"
			};

			timePickerBtn.Clicked += (sender, args) =>
			{
				timePicker.Focus();
			};

			var timePickerBtn2 = new Button
			{
				Text = "Click me to call .Unfocus on TimePicker"
			};

			timePickerBtn2.Clicked += (sender, args) =>
			{
				timePicker.Unfocus();
			};

			Content = new StackLayout
			{
				Children = {
					timePickerBtn,
					timePickerBtn2,
					timePicker,
				}
			};
		}
	}
}
