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

namespace Microsoft.Maui.Controls.ControlGallery.Issues
{
	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.Github, 4748, "Setting SelectedItem property of GTK ListView does not reflected in UI", PlatformAffected.Default)]
	public class Issue4748 : TestContentPage
	{
		protected override void Init()
		{
			var layout = new StackLayout();
			var lastItem = "Item3";
			var listView = new ListView
			{
				ItemsSource = new List<string>
				{
					"Item1",
					"Item2",
					lastItem
				}
			};

			var button = new Button
			{
				Text = "Select last item",
				AutomationId = "SelectLastItem"
			};

			button.Clicked += (_, __) => listView.SelectedItem = lastItem;
			layout.Children.Add(listView);
			layout.Children.Add(button);

			Content = layout;
		}

	}
}