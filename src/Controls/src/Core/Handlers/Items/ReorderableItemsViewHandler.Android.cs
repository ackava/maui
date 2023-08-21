﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable disable
namespace Microsoft.Maui.Controls.Handlers.Items
{
	public partial class ReorderableItemsViewHandler<TItemsView> : GroupableItemsViewHandler<TItemsView>
		where TItemsView : ReorderableItemsView
	{
		protected override ReorderableItemsViewAdapter<TItemsView, IGroupableItemsViewSource> CreateAdapter() => new(VirtualView);

		public static void MapCanReorderItems(ReorderableItemsViewHandler<TItemsView> handler, ReorderableItemsView itemsView)
		{
			(handler.PlatformView as IMauiRecyclerView<TItemsView>)?.UpdateCanReorderItems();
		}
	}
}
