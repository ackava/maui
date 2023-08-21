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

namespace Microsoft.Maui.Controls.ControlGallery.Issues
{
	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.Github, 260, "Layout issue for TableView", PlatformAffected.WinPhone)]
	public class Issue260 : ContentPage
	{
		public Issue260()
		{
			var items = Enumerable.Range(0, 50).Select(i => new TextCell
			{
				Text = i.ToString(),
				Detail = i.ToString()
			}).ToList();

			var tableSection = new TableSection("First Section");
			foreach (TextCell cell in items)
			{
				tableSection.Add(cell);
			}

			var tableRoot = new TableRoot() {
				tableSection
			};

			var tableLayout = new TableView
			{
				Root = tableRoot
			};

			tableLayout.Intent = TableIntent.Data;
			Content = tableLayout;
		}
	}
}
