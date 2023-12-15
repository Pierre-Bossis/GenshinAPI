using System.Globalization;

namespace GenshinAPI.Tools
{
    public static class DecimalConverter
    {
        public static decimal DecimalConvert(string value)
        {
            value = value.Replace(',', '.');
            return decimal.Parse(value, CultureInfo.InvariantCulture);
        }
    }
}
