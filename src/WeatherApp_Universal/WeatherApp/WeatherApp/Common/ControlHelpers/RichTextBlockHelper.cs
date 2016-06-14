using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WeatherApp.Provider;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Media;

namespace WeatherApp.Common.ControlHelpers
{
    public static class RichTextBlockHelper
    {
        public static SentenceData GetSentence(DependencyObject obj)
        {
            return (SentenceData)obj.GetValue(SentenceProperty);
        }

        public static void SetSentence(DependencyObject obj, SentenceData value)
        {
            obj.SetValue(SentenceProperty, value);
        }

        public static readonly DependencyProperty SentenceProperty =
            DependencyProperty.RegisterAttached("Sentence", typeof(SentenceData), typeof(RichTextBlockHelper), new PropertyMetadata(null, OnSentenceChanged));

        private static void OnSentenceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as RichTextBlock;
            if (control == null) return;
            control.Blocks.Clear();

            var value = (SentenceData)e.NewValue;
            var paragraph = InterpretValue(value);

            control.Blocks.Add(paragraph);
        }

        private static Paragraph InterpretValue(SentenceData value)
        {
            var paragraph = new Paragraph();
            var words = value.Phrase.Split(' ');

            foreach (var word in words)
            {
                var match = Regex.Match(word, @"(?<tag>\[highlight\])(?<text>.*)(\[\/highlight\])");
                if (!match.Success)
                {
                    paragraph.Inlines.Add(new Run() { Text = word + " " });
                    continue;
                }

                var color = ConvertStringToColor(value.Color);
                var text = match.Groups["text"].Value;

                paragraph.Inlines.Add(new Run() { Text = text + " ", Foreground = new SolidColorBrush(color) });
            }

            return paragraph;
        }

        public static Color ConvertStringToColor(string hex)
        {
            //remove the # at the front
            hex = hex.Replace("#", "");

            byte a = 255;
            byte r = 255;
            byte g = 255;
            byte b = 255;

            int start = 0;

            //handle ARGB strings (8 characters long)
            if (hex.Length == 8)
            {
                a = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                start = 2;
            }

            //convert RGB characters to bytes
            r = byte.Parse(hex.Substring(start, 2), System.Globalization.NumberStyles.HexNumber);
            g = byte.Parse(hex.Substring(start + 2, 2), System.Globalization.NumberStyles.HexNumber);
            b = byte.Parse(hex.Substring(start + 4, 2), System.Globalization.NumberStyles.HexNumber);

            return Color.FromArgb(a, r, g, b);
        }
    }
}
