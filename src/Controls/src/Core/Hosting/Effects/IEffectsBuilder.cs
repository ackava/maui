﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable disable
using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Maui.Controls.Platform;

namespace Microsoft.Maui.Controls.Hosting
{
	public interface IEffectsBuilder
	{
		IEffectsBuilder Add<TEffect, TPlatformEffect>()
			where TEffect : RoutingEffect
			where TPlatformEffect : PlatformEffect, new();

		IEffectsBuilder Add(Type TEffect, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type TPlatformEffect);
	}
}
