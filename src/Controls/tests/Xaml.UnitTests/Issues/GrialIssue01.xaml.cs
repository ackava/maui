// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using NUnit.Framework;

namespace Microsoft.Maui.Controls.Xaml.UnitTests
{
	public partial class GrialIssue01 : ContentPage
	{
		public GrialIssue01()
		{
			InitializeComponent();
		}

		public GrialIssue01(bool useCompiledXaml)
		{
			//this stub will be replaced at compile time
		}

		[TestFixture]
		class Tests
		{
			[TestCase(true)]
			[TestCase(false)]
			public void ImplicitCastIsUsedOnFileImageSource(bool useCompiledXaml)
			{
				var layout = new GrialIssue01(useCompiledXaml);
				var res = (FileImageSource)layout.Resources["image"];

				Assert.AreEqual("path.png", res.File);
			}
		}
	}
}