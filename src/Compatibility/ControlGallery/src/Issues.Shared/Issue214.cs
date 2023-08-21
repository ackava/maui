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
	[Issue(IssueTracker.Github, 214, "TextCell DetailColor change not immediate", PlatformAffected.iOS)]
	public class Issue214 : ContentPage
	{
		public Issue214()
		{
			var instructions = new Label
			{
				Text = "The text of each item should be visually distinct from the " +
				"detail of each item. If both typefaces are identical, this test has failed."
			};

			var items = Enumerable.Range(0, 50).Select(i => new TextCell
			{
				Text = "Text" + i.ToString(),
				Detail = "Detail" + i.ToString()
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
			Content = new StackLayout
			{
				Children = { instructions, tableLayout }
			};
		}
	}
}
