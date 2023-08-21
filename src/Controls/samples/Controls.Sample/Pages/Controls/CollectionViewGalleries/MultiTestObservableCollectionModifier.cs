﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.Maui.Controls;

namespace Maui.Controls.Sample.Pages.CollectionViewGalleries
{
	internal abstract class MultiTestObservableCollectionModifier : CollectionModifier
	{
		protected MultiTestObservableCollectionModifier(CollectionView cv, string buttonText) : base(cv, buttonText)
		{
		}

		protected override void OnButtonClicked()
		{
			if (!ParseIndexes(out int[] indexes))
			{
				return;
			}

			if (_cv.ItemsSource is MultiTestObservableCollection<CollectionViewGalleryTestItem> observableCollection)
			{
				ModifyObservableCollection(observableCollection, indexes);
			}
		}

		protected abstract void ModifyObservableCollection(MultiTestObservableCollection<CollectionViewGalleryTestItem> observableCollection, params int[] indexes);
	}
}