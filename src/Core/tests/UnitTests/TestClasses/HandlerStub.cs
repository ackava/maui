// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.Maui.Handlers;
namespace Microsoft.Maui.UnitTests
{
	public class HandlerStub : ViewHandler<Maui.Controls.Button, object>
	{
		public bool IsDisconnected { get; private set; }
		public int ConnectHandlerCount { get; set; } = 0;
		public int DisconnectHandlerCount { get; set; } = 0;

		public HandlerStub() : base(new PropertyMapper<IView>())
		{
		}

		public HandlerStub(PropertyMapper mapper) : base(mapper)
		{
		}

		protected override object CreatePlatformView()
		{
			return new object();
		}

		protected override void ConnectHandler(object platformView)
		{
			base.ConnectHandler(platformView);
			ConnectHandlerCount++;
		}

		protected override void DisconnectHandler(object platformView)
		{
			base.DisconnectHandler(platformView);
			DisconnectHandlerCount++;
		}
	}
}