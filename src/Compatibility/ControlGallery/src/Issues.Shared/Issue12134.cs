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
using System.Net;
using System.Threading.Tasks;
using Microsoft.Maui.Controls.CustomAttributes;
using Microsoft.Maui.Controls.Internals;


#if UITEST
using Xamarin.UITest;
using NUnit.Framework;
using Microsoft.Maui.Controls.Compatibility.UITests;
#endif

namespace Microsoft.Maui.Controls.ControlGallery.Issues
{
	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.Github, 12134, "[iOS] WkWebView does not handle cookies consistently",
		PlatformAffected.iOS)]
#if UITEST
	[NUnit.Framework.Category(Compatibility.UITests.UITestCategories.Github10000)]
	[NUnit.Framework.Category(UITestCategories.WebView)]
#endif
	public class Issue12134 : TestContentPage
	{
		Button button;
		Guid _guid = Guid.NewGuid();
		Label _label = new Label();
		protected override void Init()
		{
			WebView webView = new WebView()
			{
				HeightRequest = 400
			};

			button = new Button()
			{
				Text = "Load another webview",
				Command = new Command(() =>
				{
					OnButtonClicked(this, EventArgs.Empty);
				}),
				AutomationId = "LoadNewWebView"
			};

			Content = new StackLayout()
			{
				Children =
				{
					GetWebView(),
					_label,
					new Button(){ Text = "Display Cookies", Command = new Command(DisplayCookies) },
					button,
				}
			};

		}

		private async void DisplayCookies()
		{
			var result = await (Content as StackLayout).Children.OfType<WebView>().Last().EvaluateJavaScriptAsync("document.cookie");
			await DisplayAlert("Cookies", result, "Ok");
		}

		private async void WebViewOnNavigated(object sender, WebNavigatedEventArgs e)
		{
			var result = await ((WebView)sender).EvaluateJavaScriptAsync("document.cookie");
			_label.Text = result.Contains(_guid.ToString()) ? "Success" : "Failed";
		}

		private void OnButtonClicked(object sender, EventArgs e)
		{
			_label.Text = "";
			if (GetWebViews().Length >= 2)
			{
				foreach (var wv in GetWebViews())
					(Content as StackLayout).Children.Remove(wv);
				(Content as StackLayout).Children.Insert(0, GetWebView());
			}
			else
			{

				(Content as StackLayout).Children.Add(GetWebView());
				button.Text = "Reload the page";
			}
		}

		WebView[] GetWebViews() => (Content as StackLayout).Children.OfType<WebView>().ToArray();

		private Cookie GetTestCookie()
		{
			return new Cookie("TestCookie", $"{_guid}", "/", "dotnet.microsoft.com");
		}

		private WebView GetWebView()
		{
			var anotherWebView = new WebView
			{
				HeightRequest = 400
			};

			SetCookieContainer(anotherWebView);
			anotherWebView.Navigated += WebViewOnNavigated;
			anotherWebView.Source = "https://dotnet.microsoft.com/apps/xamarin";
			return anotherWebView;
		}

		private void SetCookieContainer(WebView wv)
		{
			wv.Cookies = new CookieContainer();
			wv.Cookies.Add(GetTestCookie());
		}

#if UITEST
		[Test]
		[NUnit.Framework.Category(UITestCategories.RequiresInternetConnection)]
		public void CookiesCorrectlyLoadWithMultipleWebViews()
		{
			for (int i = 0; i < 10; i++)
			{
				RunningApp.WaitForElement("Success", $"Failied on: {i}");
				RunningApp.Tap("LoadNewWebView");
			}
		}
#endif
	}
}
