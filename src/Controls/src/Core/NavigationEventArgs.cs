// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable disable
using System;

namespace Microsoft.Maui.Controls
{
	/// <include file="../../docs/Microsoft.Maui.Controls/NavigationEventArgs.xml" path="Type[@FullName='Microsoft.Maui.Controls.NavigationEventArgs']/Docs/*" />
	public class NavigationEventArgs : EventArgs
	{
		/// <include file="../../docs/Microsoft.Maui.Controls/NavigationEventArgs.xml" path="//Member[@MemberName='.ctor']/Docs/*" />
		public NavigationEventArgs(Page page)
		{
			if (page == null)
				throw new ArgumentNullException("page");

			Page = page;
		}

		/// <include file="../../docs/Microsoft.Maui.Controls/NavigationEventArgs.xml" path="//Member[@MemberName='Page']/Docs/*" />
		public Page Page { get; private set; }
	}
}