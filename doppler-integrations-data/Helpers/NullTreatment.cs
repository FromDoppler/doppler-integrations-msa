using System.Data.SqlTypes;
using System.Globalization;

namespace DopplerIntegrationsData.Helpers
{
    internal sealed class NullTreatment
    {
        private const string DEFAULT_STRING_VALUE = "";
        private const int DEFAULT_INT_VALUE = 0;
        private const int DEFAULT_UINT_VALUE = 0;
        private const short DEFAULT_SHORT_VALUE = 0;
        private const long DEFAULT_LONG_VALUE = 0;
        private const double DEFAULT_DOUBLE_VALUE = 0;
        private const byte DEFAULT_BYTE_VALUE = 0;
        private readonly char _dEFAULT_CHAR_VALUE = char.MinValue;

        public static string GetString(object possibleString)
        {
            try
            {
                return ((SqlString)possibleString).IsNull ? DEFAULT_STRING_VALUE : possibleString.ToString();
            }
            catch
            {
                return DEFAULT_STRING_VALUE;
            }
        }

        public char GetChar(object possibleChar)
        {
            return char.TryParse(possibleChar.ToString(), out var val)
                ? val
                : _dEFAULT_CHAR_VALUE;
        }

        public static uint GetUInt(object possibleUInt)
        {
            return uint.TryParse(possibleUInt.ToString(), CultureInfo.InvariantCulture, out var val)
                ? val
                : DEFAULT_UINT_VALUE;
        }

        public static int GetInt(object possibleInt)
        {
            return int.TryParse(possibleInt.ToString(), CultureInfo.InvariantCulture, out var val)
                ? val
                : DEFAULT_INT_VALUE;
        }

        public static long GetLong(object possibleLong)
        {
            return long.TryParse(possibleLong.ToString(), CultureInfo.InvariantCulture, out var val)
                ? val
                : DEFAULT_LONG_VALUE;
        }

        public static double GetDouble(object possibleDouble)
        {
            return double.TryParse(possibleDouble.ToString(), CultureInfo.InvariantCulture, out var val)
                ? val
                : DEFAULT_DOUBLE_VALUE;
        }

        public static bool GetBoolean(object possibleBoolean)
        {
            return bool.TryParse(possibleBoolean.ToString(), out var val) && val;
        }

        public static DateTime GetDateTime(object possibleDateTime)
        {
            return DateTime.TryParse(possibleDateTime.ToString(), CultureInfo.InvariantCulture, out var val)
                ? val
                : DateTime.MinValue;
        }

        public static DateTime? GetNullableDateTime(object possibleDateTime)
        {
            return possibleDateTime == null || possibleDateTime == DBNull.Value
                ? null
                : DateTime.TryParse(possibleDateTime.ToString(), CultureInfo.InvariantCulture, out var val)
                ? val
                : (DateTime?)null;
        }

        public static byte GetByte(object possibleByte)
        {
            return byte.TryParse(possibleByte.ToString(), CultureInfo.InvariantCulture, out var val)
                ? val
                : DEFAULT_BYTE_VALUE;
        }

        public static short GetShort(object possibleShort)
        {
            return short.TryParse(possibleShort.ToString(), CultureInfo.InvariantCulture, out var val)
                ? val
                : DEFAULT_SHORT_VALUE;
        }

        public static object GetObject(object possibleObject)
        {
            return possibleObject;
        }
    }
}
