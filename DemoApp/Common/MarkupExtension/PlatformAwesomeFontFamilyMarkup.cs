using DemoApp.Common.Utils;
using System;
using Xamarin.Forms.Xaml;

namespace DemoApp.Common.MarkupExtension
{
    public class PlatformAwesomeFontFamilyMarkup : IMarkupExtension<string>
    {
        public Resources.Fonts.FontAwesomeIcon.EnumIcon Icon { get; set; }
        public string Text { get; set; } = "";

        public string ProvideValue(IServiceProvider serviceProvider)
        {
            return Icon == null ? Text : string.Format(Text, Icon.GetDescription());
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return ProvideValue(serviceProvider);
        }
    }
}
