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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Microsoft.Maui.Controls.CustomAttributes;
using Microsoft.Maui.Controls.Internals;
using Microsoft.Maui.Graphics;


#if UITEST
using Xamarin.UITest;
using NUnit.Framework;
using Microsoft.Maui.Controls.Compatibility.UITests;
#endif

namespace Microsoft.Maui.Controls.ControlGallery.Issues
{
	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.Github, 1658, "[macOS] GestureRecognizer on ListView Item not working",
		PlatformAffected.macOS)]
#if UITEST
	[NUnit.Framework.Category(UITestCategories.ListView)]
	[NUnit.Framework.Category(Compatibility.UITests.UITestCategories.Github5000)]
#endif
	public class Issue1658 : TestNavigationPage
	{
		protected override void Init()
		{
			var page = new ContentPage();

			PushAsync(page);

			page.Content = new ListView()
			{
				ItemsSource = new[] { "1" },
				ItemTemplate = new DataTemplate(() =>
				{
					ViewCell cells = new ViewCell();

					cells.ContextActions.Add(new MenuItem()
					{
						IconImageSource = "coffee.png",
						AutomationId = "coffee.png"
					});

					var box = new BoxView
					{
						WidthRequest = 30,
						HeightRequest = 30,
						Color = Colors.Red,
						AutomationId = "ColorBox"
					};

					var gr = new TapGestureRecognizer();
					gr.Command = new Command(() =>
					{
						box.Color = box.Color == Colors.Red ? Colors.Yellow : Colors.Red;
					});
					box.GestureRecognizers.Add(gr);
					cells.View = new StackLayout()
					{
						Orientation = StackOrientation.Horizontal,
						Children =
						{
							new Label()
							{
								Text = "Right click on any item within viewcell (including this label) should trigger context action on this row and you should see a coffee cup. Tap on colored box should change box color",
								AutomationId = "ListViewItem"
							},
							box
						}
					};

					return cells;
				})
			};
		}

#if UITEST && __MACOS__
		[Test]
		public void ContextActionsIconImageSource()
		{
			RunningApp.ActivateContextMenu("ListViewItem");
			RunningApp.WaitForElement("coffee.png");
			RunningApp.DismissContextMenu();

			RunningApp.WaitForElement("ColorBox");
			RunningApp.Screenshot("Box should be red");
			RunningApp.Tap("ColorBox");
			RunningApp.Screenshot("Box should be yellow");
		}
#endif
	}
}
