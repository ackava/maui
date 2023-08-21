// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Windows;
using GraphicsTester.Scenarios;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Graphics.Skia;

namespace GraphicsTester.WPF.Skia
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			Initialize();
		}

		public void Initialize()
		{
			GraphicsView.BackgroundColor = Colors.White;

			foreach (var scenario in ScenarioList.Scenarios)
			{
				List.Items.Add(scenario);
			}
			List.SelectionChanged += OnSelectionChanged;
			List.SelectedIndex = 0;

			this.SizeChanged += (source, args) => Draw();
		}

		public IDrawable Drawable
		{
			set
			{
				GraphicsView.Drawable = value;
				Draw();
			}
		}

		private void Draw()
		{
			GraphicsView.Invalidate();
		}

		private void OnSelectionChanged(object source, System.Windows.Controls.SelectionChangedEventArgs args)
		{
			AbstractScenario scenario = (AbstractScenario)List.SelectedItem;
			Drawable = scenario;
			GraphicsView.Width = scenario.Width;
			GraphicsView.Height = scenario.Height;
			this.Title = $"WPF Maui Graphics Sample: {scenario}";
			Draw();
		}
	}
}
