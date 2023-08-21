// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace Microsoft.Maui.Controls
{
	/// <include file="../../docs/Microsoft.Maui.Controls/ToggledEventArgs.xml" path="Type[@FullName='Microsoft.Maui.Controls.ToggledEventArgs']/Docs/*" />
	public class ToggledEventArgs : EventArgs
	{
		/// <include file="../../docs/Microsoft.Maui.Controls/ToggledEventArgs.xml" path="//Member[@MemberName='.ctor']/Docs/*" />
		public ToggledEventArgs(bool value)
		{
			Value = value;
		}

		/// <include file="../../docs/Microsoft.Maui.Controls/ToggledEventArgs.xml" path="//Member[@MemberName='Value']/Docs/*" />
		public bool Value { get; private set; }
	}
}