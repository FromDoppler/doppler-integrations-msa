using System;
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
        private const bool DEFAULT_BOOLEAN_VALUE = false;
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
            try
            {
                var val = char.Parse(possibleChar.ToString());
                return val;
            }
            catch
            {
                return _dEFAULT_CHAR_VALUE;
            }
        }

        public static uint GetUInt(object possibleUInt)
        {
            try
            {
                var val = uint.Parse(possibleUInt.ToString(), CultureInfo.InvariantCulture);
                return val;
            }
            catch
            {
                return DEFAULT_UINT_VALUE;
            }
        }

        public static int GetInt(object possibleInt)
        {
            try
            {
                var val = int.Parse(possibleInt.ToString(), CultureInfo.InvariantCulture);
                return val;
            }
            catch
            {
                return DEFAULT_INT_VALUE;
            }
        }

        public static long GetLong(object possibleLong)
        {
            try
            {
                var val = long.Parse(possibleLong.ToString(), CultureInfo.InvariantCulture);
                return val;
            }
            catch
            {
                return DEFAULT_LONG_VALUE;
            }
        }

        public static double GetDouble(object possibleDouble)
        {
            try
            {
                var val = double.Parse(possibleDouble.ToString(), CultureInfo.InvariantCulture);
                return val;
            }
            catch
            {
                return DEFAULT_DOUBLE_VALUE;
            }
        }

        public static bool GetBoolean(object possibleBoolean)
        {
            try
            {
                var val = bool.Parse(possibleBoolean.ToString());
                return val;
            }
            catch
            {
                return DEFAULT_BOOLEAN_VALUE;
            }
        }

        public static DateTime GetDateTime(object possibleDateTime)
        {
            try
            {
                var val = DateTime.Parse(possibleDateTime.ToString(), CultureInfo.InvariantCulture);
                return val;
            }
            catch
            {
                return DateTime.MinValue;
            }
        }

        public static byte GetByte(object possibleByte)
        {
            try
            {
                var val = byte.Parse(possibleByte.ToString(), CultureInfo.InvariantCulture);
                return val;
            }
            catch
            {
                return DEFAULT_BYTE_VALUE;
            }
        }

        public static short GetShort(object possibleShort)
        {
            try
            {
                var val = short.Parse(possibleShort.ToString(), CultureInfo.InvariantCulture);
                return val;
            }
            catch
            {
                return DEFAULT_SHORT_VALUE;
            }
        }

        public static object GetObject(object possibleObject)
        {
            return possibleObject;
        }
    }
}
