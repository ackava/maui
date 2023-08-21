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
using System.Threading;
using Microsoft.Maui.Controls.CustomAttributes;
using Microsoft.Maui.Controls.Internals;
using Microsoft.Maui.Graphics;

#if UITEST
using Xamarin.UITest;
using Xamarin.UITest.iOS;
using Xamarin.UITest.Android;
using NUnit.Framework;
#endif

namespace Microsoft.Maui.Controls.ControlGallery.Issues
{
#if UITEST
	[NUnit.Framework.Category(Compatibility.UITests.UITestCategories.Github5000)]
#endif
	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.Github, 2948, "FlyoutPage Detail is interactive even when Flyout is open when in Landscape")]
	public class Issue2948 : TestFlyoutPage
	{
		static FlyoutPage s_mdp;

		protected override void Init()
		{
			s_mdp = this;
			var menuPage = new MenuPage();

			menuPage.Menu.ItemSelected += (sender, e) => NavigateTo(e.SelectedItem as MenuItem);

			Flyout = menuPage;
			Detail = new NavigationPage(new ContractsPage());
		}

		[Preserve(AllMembers = true)]
		public class MenuListData : List<MenuItem>
		{
			public MenuListData()
			{
				Add(new MenuItem()
				{
					Title = "Contracts",
					IconSource = "bank.png",
					TargetType = typeof(ContractsPage)
				});

				Add(new MenuItem()
				{
					Title = "Leads",
					IconSource = "bank.png",
					TargetType = typeof(ContractsPage)
				});

				Add(new MenuItem()
				{
					Title = "Accounts",
					IconSource = "bank.png",
					TargetType = typeof(ContractsPage)
				});

				Add(new MenuItem()
				{
					Title = "Opportunities",
					IconSource = "bank.png",
					TargetType = typeof(ContractsPage)
				});
			}
		}

		[Preserve(AllMembers = true)]
		public class ContractsPage : ContentPage
		{
			public ContractsPage()
			{
				Title = "Contracts";
				IconImageSource = "bank.png";

				var grid = new Grid();
				grid.ColumnDefinitions.Add(new ColumnDefinition());
				grid.ColumnDefinitions.Add(new ColumnDefinition());

				var btn = new Button
				{
					HeightRequest = 300,
					HorizontalOptions = LayoutOptions.End,
					BackgroundColor = Colors.Pink,
					AutomationId = "btnOnDetail"
				};

				btn.Clicked += (object sender, EventArgs e) =>
				{
					DisplayAlert("Clicked", "I was clicked", "Ok");
				};

				Grid.SetColumn(btn, 1);

				grid.Children.Add(btn);

				var showMasterButton = new Button
				{
					AutomationId = "ShowMasterBtn",
					Text = "Show Flyout"
				};
				showMasterButton.Clicked += (sender, e) =>
				{
					s_mdp.IsPresented = true;
				};

				Content = new ScrollView
				{

					Content = new StackLayout
					{
						Children = {
							showMasterButton,
							grid,
							new BoxView {
								HeightRequest = 100,
								Color = Colors.Red,
							},
							new BoxView {
								HeightRequest = 200,
								Color = Colors.Green,
							},
							new BoxView {
								HeightRequest = 300,
								Color = Colors.Red,
							},
							new BoxView {
								HeightRequest = 400,
								Color = Colors.Green,
							},
							new BoxView {
								HeightRequest = 500,
								Color = Colors.Red,
							}
						}
					},

				};
			}
		}

		[Preserve(AllMembers = true)]
		public class MenuListView : ListView
		{
			public MenuListView()
			{
				List<MenuItem> data = new MenuListData();

				ItemsSource = data;
				VerticalOptions = LayoutOptions.FillAndExpand;
				BackgroundColor = Colors.Transparent;

				var cell = new DataTemplate(typeof(ImageCell));
				cell.SetBinding(TextCell.TextProperty, "Title");
				cell.SetBinding(ImageCell.ImageSourceProperty, "IconSource");

				ItemTemplate = cell;
				SelectedItem = data[0];
			}
		}

		public class MenuPage : ContentPage
		{
			public ListView Menu { get; set; }

			public MenuPage()
			{
				Title = "Menu";
				BackgroundColor = Color.FromArgb("333333");

				Menu = new MenuListView();

				var menuLabel = new ContentView
				{
					Padding = new Thickness(10, 36, 0, 5),
					Content = new Label
					{
						TextColor = Color.FromArgb("AAAAAA"),
						Text = "MENU",
					}
				};

				var layout = new StackLayout
				{
					Spacing = 0,
					VerticalOptions = LayoutOptions.FillAndExpand
				};
				layout.Children.Add(menuLabel);
				layout.Children.Add(Menu);

				Content = layout;
			}
		}

		void NavigateTo(MenuItem menu)
		{
			var displayPage = (Page)Activator.CreateInstance(menu.TargetType);

			Detail = new NavigationPage(displayPage);

		}

		[Preserve(AllMembers = true)]
		public class MenuItem
		{
			public string Title { get; set; }

			public string IconSource { get; set; }

			public Type TargetType { get; set; }
		}

#if UITEST
		[Test]
		public void Issue2948Test()
		{
			RunningApp.Screenshot("I am at Issue 2948");
			RunningApp.SetOrientationLandscape();
			Thread.Sleep(5000);
			if (ShouldRunTest())
			{
				OpenMDP();
				var btns = RunningApp.Query(c => c.Marked("btnOnDetail"));
				if (btns.Length > 0)
				{
					// on iOS the button could be out of screen
					RunningApp.Tap(c => c.Marked("btnOnDetail"));
					RunningApp.Screenshot("I in landscape and master is open");
				}
				RunningApp.WaitForNoElement(c => c.Marked("Clicked"), "Time out", new TimeSpan(0, 0, 1));
			}
		}

		[TearDown]
		public void TestTearDown()
		{
			RunningApp.SetOrientationPortrait();
		}

		public bool ShouldRunTest()
		{
			var isMasterVisible = RunningApp.Query(q => q.Marked("Leads")).Length > 0;
			return !isMasterVisible;
		}
		public void OpenMDP()
		{
#if __IOS__
			RunningApp.Tap(q => q.Marked("Menu"));
#else
			RunningApp.Tap ("ShowMasterBtn");
#endif
		}
#endif
	}
}
