﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace Maui.Controls.Sample.Pages.CollectionViewGalleries
{
	internal class ItemInserter : ObservableCollectionModifier
	{
		public ItemInserter(CollectionView cv) : base(cv, "Insert")
		{
		}

		protected override void ModifyObservableCollection(ObservableCollection<CollectionViewGalleryTestItem> observableCollection, params int[] indexes)
		{
			var index = indexes[0];

			if (index > -1 && index <= observableCollection.Count)
			{
				var item = new CollectionViewGalleryTestItem(DateTime.Now, "Inserted", "oasis.jpg", index);
				observableCollection.Insert(index, item);
			}
		}
	}
}

