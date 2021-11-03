using System;
using System.Globalization;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace DemoApp.Common.MarkupExtension
{
    [Preserve(AllMembers = true)]
    [ContentProperty(nameof(SourceImage))]
    public class EmbeddedImageResource : IMarkupExtension
    {
        public string SourceImage { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (SourceImage == null)
                return null;
            SourceImage = "DemoApp.Resources.Images." + SourceImage;
            // Do your translation lookup here, using whatever method you require
            var imageSource = ImageSource.FromResource(SourceImage, typeof(EmbeddedImageResource).GetTypeInfo().Assembly);

            return imageSource;
        }
    }

    public class EmbeddedImageResourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var Source = "DemoApp.Resources.Images." + value.ToString();
            return ImageSource.FromResource(Source, typeof(EmbeddedImageResource).GetTypeInfo().Assembly);
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
