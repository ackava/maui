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

using Microsoft.Maui.Controls.CustomAttributes;
using Microsoft.Maui.Controls.Internals;

namespace Microsoft.Maui.Controls.ControlGallery.Issues
{
	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.Github, 4053, "AutomationProperties.Name on Button is visible on Android", PlatformAffected.Android)]
	public class Issue4053 : TestContentPage
	{
		protected override void Init()
		{
			Button button = new Button();
			Switch _switch = new Switch();
			AutomationProperties.SetName(button, "invisible text");
			AutomationProperties.SetName(_switch, "invisible text");

			Content = new StackLayout
			{
				Children = {
					new Label { Text = "The text on the controls below should be empty. But TalkBack should read 'invisible text'" },
					button,
					_switch
				}
			};
		}
	}
}