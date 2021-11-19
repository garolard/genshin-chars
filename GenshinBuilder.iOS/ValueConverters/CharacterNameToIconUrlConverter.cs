using System;
using System.Globalization;
using MvvmCross.Converters;

namespace GenshinBuilder.iOS.ValueConverters
{
    public class CharacterNameToIconUrlConverter : MvxValueConverter<string, string>
    {
        public CharacterNameToIconUrlConverter()
        {
        }

        protected override string Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"https://api.genshin.dev/characters/{value}/icon";
        }
    }
}
