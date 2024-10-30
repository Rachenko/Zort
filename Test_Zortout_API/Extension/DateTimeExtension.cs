using System.Globalization;

namespace Test_Zortout_API.Extension
{
    public class DateTimeExtension
    {
        public static bool CheckFormatDate(string date) 
        {
            bool result = false;
            DateTime dt;
            string[] formats = { "yyyy-MM-dd" };
            if (DateTime.TryParseExact(date, formats, CultureInfo.InvariantCulture,
                                      DateTimeStyles.None, out dt))
            {
                result = true;
            }

            return result;
        }

        public static DateTime ConvertDateTimeFromString(string date)
        {
            DateTime result = DateTime.MaxValue;
            DateTime dt;
            string[] formats = { "yyyy-MM-dd" };
            if (DateTime.TryParseExact(date, formats, CultureInfo.InvariantCulture,
                                      DateTimeStyles.None, out dt))
            {
                result = dt;
            }
            return result;
        }
    }
}
