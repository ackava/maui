// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace Microsoft.Maui.Controls
{
	/// <include file="../../docs/Microsoft.Maui.Controls/MeasureFlags.xml" path="Type[@FullName='Microsoft.Maui.Controls.MeasureFlags']/Docs/*" />
	[Flags]
	public enum MeasureFlags
	{
		/// <include file="../../docs/Microsoft.Maui.Controls/MeasureFlags.xml" path="//Member[@MemberName='None']/Docs/*" />
		None = 0,
		/// <include file="../../docs/Microsoft.Maui.Controls/MeasureFlags.xml" path="//Member[@MemberName='IncludeMargins']/Docs/*" />
		IncludeMargins = 1 << 0
	}
}