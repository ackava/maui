// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Samples.View;
using Device = Microsoft.Maui.Controls.Device;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace Samples
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new HomePage());
		}

		public static void HandleAppActions(AppAction appAction)
		{
			App.Current.Dispatcher.Dispatch(async () =>
			{
				var page = appAction.Id switch
				{
					"battery_info" => new BatteryPage(),
					"app_info" => new AppInfoPage(),
					_ => default(Page)
				};

				if (page != null)
				{
					await Application.Current.MainPage.Navigation.PopToRootAsync();
					await Application.Current.MainPage.Navigation.PushAsync(page);
				}
			});
		}
	}
}
