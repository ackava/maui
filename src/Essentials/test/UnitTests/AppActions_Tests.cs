// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Microsoft.Maui.ApplicationModel;
using Xunit;

namespace Tests
{
	public class AppActions_Tests
	{
		[Fact]
		public void AppActions_SetActions() =>
			Assert.ThrowsAsync<NotImplementedInReferenceAssemblyException>(() => AppActions.SetAsync(new List<AppAction>()));

		[Fact]
		public void AppActions_GetActions() =>
			Assert.ThrowsAsync<NotImplementedInReferenceAssemblyException>(() => AppActions.GetAsync());

		[Fact]
		public void AppActions_IsSupported() =>
			Assert.Throws<NotImplementedInReferenceAssemblyException>(() => AppActions.IsSupported);
	}
}
