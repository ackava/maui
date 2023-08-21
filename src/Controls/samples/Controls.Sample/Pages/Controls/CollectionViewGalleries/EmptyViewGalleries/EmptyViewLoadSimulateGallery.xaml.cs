﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Dispatching;

namespace Maui.Controls.Sample.Pages.CollectionViewGalleries.EmptyViewGalleries
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EmptyViewLoadSimulateGallery : ContentPage
	{
		readonly DemoFilteredItemSource _demoFilteredItemSource = new DemoFilteredItemSource();

		public EmptyViewLoadSimulateGallery()
		{
			InitializeComponent();

			CollectionView.ItemTemplate = ExampleTemplates.PhotoTemplate();

			Task.Run(async () =>
			{
				await Task.Delay(1000);
				Dispatcher.Dispatch(() => CollectionView.ItemsSource = new List<object>());
				await Task.Delay(1000);
				Dispatcher.Dispatch(() => CollectionView.ItemsSource = _demoFilteredItemSource.Items);
			});
		}
	}
}