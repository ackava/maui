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

using Android.Content;

namespace Microsoft.Maui.Controls.Compatibility.Platform.Android.AppCompat
{
	[System.Obsolete("Use Microsoft.Maui.Controls.Handlers.Compatibility.ViewRenderer instead")]
	public abstract class ViewRenderer<TView, TControl> : Android.ViewRenderer<TView, TControl> where TView : View where TControl : global::Android.Views.View
	{
		protected ViewRenderer(Context context) : base(context)
		{
		}
	}
}