using Newtonsoft.Json.Converters;

namespace Hiker.API.Converters
{
    public class DateTimeConverter : IsoDateTimeConverter
    {
        public DateTimeConverter(string format)
        {
            base.DateTimeFormat = format;
        }
    }
}