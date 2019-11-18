using DAL.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace DAL.Service
{
    public class AnimationService
    {
        public static async void AnimateGrid(Grid grid, string text)
        {
            var textBlock = new TextBlock
            {
                Text = text,
                FontSize = 140,
                Foreground = Brushes.CornflowerBlue,
                FontFamily = new FontFamily("Century Gothic"),
                FontStretch = FontStretches.Condensed,
                FontStyle = FontStyles.Normal,
                FontWeight = FontWeights.UltraBlack,
                TextAlignment = TextAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            DoubleAnimation FadeOut = new DoubleAnimation(1.0, 0.0, TimeSpan.FromSeconds(1));
            DoubleAnimation FadeIn = new DoubleAnimation(0.0, 1.0, TimeSpan.FromSeconds(1));
            grid.BeginAnimation(Grid.OpacityProperty, FadeOut);
            await Task.Delay(1000);
            grid.Children.Clear();
            grid.Children.Add(textBlock);
            grid.BeginAnimation(Grid.OpacityProperty, FadeIn);
        }
    }
}
