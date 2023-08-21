﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.Maui.Handlers;
namespace Microsoft.Maui.Maps.Handlers
{
	public partial class MapElementHandler : ElementHandler<IMapElement, object>
	{
		protected override object CreatePlatformElement() => throw new System.NotImplementedException();
		public static void MapStroke(IMapElementHandler handler, IMapElement mapElement) => throw new System.NotImplementedException();
		public static void MapStrokeThickness(IMapElementHandler handler, IMapElement mapElement) => throw new System.NotImplementedException();
		public static void MapFill(IMapElementHandler handler, IMapElement mapElement) => throw new System.NotImplementedException();
	}
}
