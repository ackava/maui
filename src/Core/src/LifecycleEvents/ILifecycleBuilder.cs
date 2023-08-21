﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace Microsoft.Maui.LifecycleEvents
{
	public interface ILifecycleBuilder
	{
		void AddEvent<TDelegate>(string eventName, TDelegate action)
			where TDelegate : Delegate;
	}
}