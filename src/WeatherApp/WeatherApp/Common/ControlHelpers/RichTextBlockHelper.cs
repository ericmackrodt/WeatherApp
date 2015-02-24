using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Media;

namespace WeatherApp.Common.ControlHelpers
{
    public static class RichTextBlockHelper
    {
        public static string GetText(DependencyObject obj)
        {
            return (string)obj.GetValue(TextProperty);
        }

        public static void SetText(DependencyObject obj, string value)
        {
            obj.SetValue(TextProperty, value);
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.RegisterAttached("Text", typeof(string), typeof(RichTextBlockHelper), new PropertyMetadata(null, OnTextChanged));

        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as RichTextBlock;
            if (control == null) return;
            control.Blocks.Clear();

            var value = e.NewValue.ToString();
            var paragraph = InterpretValue(value);

            control.Blocks.Add(paragraph);
        }

        private static Paragraph InterpretValue(string value)
        {
            var paragraph = new Paragraph();
            var words = value.Split(' ');

            foreach (var word in words)
            {
                var match = Regex.Match(word, @"(?<tag>(\[cold\])|(\[hot\])|(\[clouds\]))(?<text>[\w]*)((\[\/cold\])|(\[\/hot\])|(\[\/clouds\]))");
                if (!match.Success)
                {
                    paragraph.Inlines.Add(new Run() { Text = word + " " });
                    continue;
                }

                var type = "";

                switch (match.Groups["tag"].Value)
                {
                    case "[hot]":
                        type = "HotColor";
                        break;
                    case "[cold]":
                        type = "ColdColor";
                        break;
                    case "[clouds]":
                    default:
                        type = "CloudsColor";
                        break;
                }


                paragraph.Inlines.Add(new Run() { Text = match.Groups["text"].Value + " ", Foreground = Application.Current.Resources[type] as SolidColorBrush });
            }

            return paragraph;
        }
    }
}
