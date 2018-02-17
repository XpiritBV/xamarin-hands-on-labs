using Quotes.Effects;
using Quotes.UWP.Effects;
using System;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ResolutionGroupName("MyCompany")]
[assembly: ExportEffect(typeof(LabelShadowEffect), "LabelShadowEffect")]

namespace Quotes.UWP.Effects
{
    public class LabelShadowEffect : PlatformEffect
    {
        bool shadowAdded = false;

        protected override void OnAttached()
        {
            try
            {
                if (!shadowAdded)
                {
                    var effect = (ShadowEffect)Element.Effects.FirstOrDefault(e => e is ShadowEffect);
                    if (effect != null)
                    {
                        var targetLabel = Element as Label;
                        var shadowLabel = new Label
                        {
                            Text = targetLabel.Text,
                            FontAttributes = targetLabel.FontAttributes,
                            FontSize = targetLabel.FontSize,
                            HorizontalOptions = targetLabel.HorizontalOptions,
                            VerticalOptions = targetLabel.VerticalOptions,
                            HorizontalTextAlignment = targetLabel.HorizontalTextAlignment,
                            VerticalTextAlignment = targetLabel.VerticalTextAlignment,
                            TextColor = effect.Color,
                            TranslationX = effect.DistanceX,
                            TranslationY = effect.DistanceY
                        };

                        ((Grid)Element.Parent).Children.Insert(0, shadowLabel);
                        shadowAdded = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Cannot set property on attached control. Error: {ex.Message}");
            }
        }

        protected override void OnDetached()
        {
        }
    }
}
