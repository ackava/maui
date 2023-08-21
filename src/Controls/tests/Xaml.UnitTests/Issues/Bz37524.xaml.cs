// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using NUnit.Framework;

namespace Microsoft.Maui.Controls.Xaml.UnitTests
{
	public partial class Bz37524 : ContentPage
	{
		public Bz37524()
		{
			InitializeComponent();
		}

		public Bz37524(bool useCompiledXaml)
		{
			//this stub will be replaced at compile time
		}

		[TestFixture]
		class Tests
		{
			[TestCase(true)]
			[TestCase(false)]
			public void MultiTriggerConditionNotApplied(bool useCompiledXaml)
			{
				var layout = new Bz37524(useCompiledXaml);
				Assert.AreEqual(false, layout.TheButton.IsEnabled);
			}
		}
	}
}