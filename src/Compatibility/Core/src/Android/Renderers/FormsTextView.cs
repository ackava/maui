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
using Android.Content;
using Android.Runtime;
using Android.Util;
using AndroidX.AppCompat.Widget;

namespace Microsoft.Maui.Controls.Compatibility.Platform.Android
{
	public class FormsTextView : AppCompatTextView
	{
		public FormsTextView(Context context) : base(context)
		{
		}

		[Obsolete]
		public FormsTextView(Context context, IAttributeSet attrs) : base(context, attrs)
		{
		}

		[Obsolete]
		public FormsTextView(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
		{
		}

		[Obsolete]
		protected FormsTextView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
		{
		}

		[Obsolete]
		public void SkipNextInvalidate()
		{
		}
	}
}