﻿using Xamarin.Forms;

namespace Quotes.Effects
{
    public class ShadowEffect : RoutingEffect
    {
        public float Radius { get; set; }

        public Color Color { get; set; }

        public float DistanceX { get; set; }

        public float DistanceY { get; set; }

        public ShadowEffect() : base("MyCompany.LabelShadowEffect")
        {
        }
    }
}