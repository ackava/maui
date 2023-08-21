//using System;
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

using System;
using AppKit;
using CoreGraphics;
using Foundation;
using ObjCRuntime;

namespace GraphicsTester.Mac
{
	public partial class AppDelegate : NSApplicationDelegate
	{
		MainWindowController mainWindowController;

		public AppDelegate()
		{
		}

		public override void DidFinishLaunching(NSNotification notification)
		{
			mainWindowController = new MainWindowController();
			mainWindowController.Window.MakeKeyAndOrderFront(this);
		}
	}
}
