﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Android.App;
//using Android.Content;
//using Android.Content.PM;
//using Android.OS;
//using Android.Renderscripts;
//using Android.Runtime;
//using Android.Views;
//using Android.Widget;
//using Microsoft.Maui.Controls.ControlGallery.Issues;

using System.Collections.Generic;
using Microsoft.Maui.Controls.CustomAttributes;
using Microsoft.Maui.Controls.Internals;
using Microsoft.Maui.Controls.Shapes;

#if UITEST
using Xamarin.UITest;
using NUnit.Framework;
using Microsoft.Maui.Controls.Compatibility.UITests;
#endif

namespace Microsoft.Maui.Controls.ControlGallery.Issues
{
#if UITEST
	[Category(UITestCategories.Shape)]
#endif
	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.Github, 11653,
		"[Bug] Polygon.Points doesn't respond to CollectionChanged events",
		PlatformAffected.All)]
	public partial class Issue11653 : TestContentPage
	{
		public Issue11653()
		{
#if APP
			InitializeComponent();
#endif
		}

		protected override void Init()
		{

		}
	}
}