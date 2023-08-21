// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using NUnit.Framework;

namespace Microsoft.Maui.Controls.Xaml.UnitTests
{
	public class Issue2742BasePage : ContentPage
	{

	}

	public partial class Issue2742 : Issue2742BasePage
	{
		public Issue2742()
		{
			InitializeComponent();
		}

		public Issue2742(bool useCompiledXaml)
		{
			//this stub will be replaced at compile time
		}


		[TestFixture]
		public class Tests
		{
			[TestCase(false)]
			[TestCase(true)]
			public void ToolBarItemsOnContentPageInheritors(bool useCompiledXaml)
			{
				var layout = new Issue2742(useCompiledXaml);
				Assert.That(layout.Content, Is.TypeOf<Label>());
				Assert.AreEqual("test", ((Label)layout.Content).Text);

				Assert.NotNull(layout.ToolbarItems);
				Assert.AreEqual(2, layout.ToolbarItems.Count);
				Assert.AreEqual("One", layout.ToolbarItems[0].Text);
			}
		}
	}
}