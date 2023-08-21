//using System;
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
using Microsoft.Maui.Graphics;

namespace Microsoft.Maui.Controls.ControlGallery
{
	internal class TableViewCoreGalleryPage : CoreGalleryPage<TableView>
	{
		// TODO
		protected override bool SupportsFocus
		{
			get { return false; }
		}

		protected override void Build(StackLayout stackLayout)
		{
			base.Build(stackLayout);

			var tableSectionContainer = new ViewContainer<TableView>(Test.TableView.TableSection, new TableView());
			var section = new TableSection("Test")
			{
				TextColor = Colors.Red
			};

			section.Add(new TextCell { Text = "Worked!" });

			var section1 = new TableSection("Testing")
			{
				TextColor = Colors.Green
			};

			section1.Add(new TextCell { Text = "Workeding!" });

			var section2 = new TableSection("Test old")
			{
				new TextCell { Text = "Worked old!" }
			};

			tableSectionContainer.View.Root.Add(section);
			tableSectionContainer.View.Root.Add(section1);
			tableSectionContainer.View.Root.Add(section2);

			Add(tableSectionContainer);
		}
	}
}