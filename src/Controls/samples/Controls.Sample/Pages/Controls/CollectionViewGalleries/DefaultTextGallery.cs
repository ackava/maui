﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace Maui.Controls.Sample.Pages.CollectionViewGalleries
{
	internal class DefaultTextGallery : ContentPage
	{
		public DefaultTextGallery()
		{
			var descriptionLabel = new Label
			{
				Text = "No DataTemplates; just using the ToString() of the objects in the source.",
				Margin = new Thickness(2, 2, 2, 2)
			};

			Title = "Default Text Galleries";

			Content = new ScrollView
			{
				Content = new StackLayout
				{
					Children =
					{
						// TODO hartez 2018-06-05 10:43 AM Need a gallery page which allows layout selection
						// so we can demonstrate switching between them
						descriptionLabel,
						GalleryBuilder.NavButton("Vertical List (Code)", () =>
							new TextCodeCollectionViewGallery(LinearItemsLayout.Vertical), Navigation),
						GalleryBuilder.NavButton("Horizontal List (Code)", () =>
							new TextCodeCollectionViewGallery(LinearItemsLayout.Horizontal), Navigation),
						GalleryBuilder.NavButton("Vertical Grid (Code)", () =>
							new TextCodeCollectionViewGridGallery(), Navigation),
						GalleryBuilder.NavButton("Horizontal Grid (Code)", () =>
							new TextCodeCollectionViewGridGallery(ItemsLayoutOrientation.Horizontal), Navigation),
					}
				}
			};
		}
	}
}