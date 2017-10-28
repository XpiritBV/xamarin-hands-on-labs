﻿using System;
using System.Linq;
using Quotes.Droid.Effects;
using Quotes.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("MyCompany")]
[assembly: ExportEffect(typeof(LabelShadowEffect), "LabelShadowEffect")]

namespace Quotes.Droid.Effects
{
	public class LabelShadowEffect : PlatformEffect
	{
		protected override void OnAttached()
		{
			try
			{
				var control = Control as Android.Widget.TextView;
				var effect = (ShadowEffect)Element.Effects.FirstOrDefault(e => e is ShadowEffect);
				if (effect != null)
				{
					float radius = effect.Radius;
					float distanceX = effect.DistanceX;
					float distanceY = effect.DistanceY;
					Android.Graphics.Color color = effect.Color.ToAndroid();
					control.SetShadowLayer(radius, distanceX, distanceY, color);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Cannot set property on attached control. Error: {ex.Message}");
			}
		}

		protected override void OnDetached()
		{
		}
	}
}