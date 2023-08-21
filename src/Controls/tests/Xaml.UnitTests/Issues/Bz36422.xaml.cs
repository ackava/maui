// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Microsoft.Maui.Controls;
using NUnit.Framework;

namespace Microsoft.Maui.Controls.Xaml.UnitTests
{
	public class Bz36422Control : ContentView
	{
		public IList<ContentView> Views { get; set; }
	}

	public partial class Bz36422 : ContentPage
	{
		public Bz36422()
		{
			InitializeComponent();
		}

		public Bz36422(bool useCompiledXaml)
		{
			//this stub will be replaced at compile time
		}

		[TestFixture]
		class Tests
		{
			[TestCase(true)]
			[TestCase(false)]
			public void xArrayCanBeAssignedToIListT(bool useCompiledXaml)
			{
				var layout = new Bz36422(useCompiledXaml);
				Assert.AreEqual(3, layout.control.Views.Count);
			}
		}
	}
}