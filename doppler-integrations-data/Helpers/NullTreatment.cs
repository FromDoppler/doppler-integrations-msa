using System;
using System.Data.SqlTypes;

namespace DopplerIntegrationsData.Helpers
{
    internal class NullTreatment
    {
        private const string DEFAULT_STRING_VALUE = "";
        private const int DEFAULT_INT_VALUE = 0;
        private const int DEFAULT_UINT_VALUE = 0;
        private const short DEFAULT_SHORT_VALUE = 0;
        private const long DEFAULT_LONG_VALUE = 0;
        private const double DEFAULT_DOUBLE_VALUE = 0;
        private const bool DEFAULT_BOOLEAN_VALUE = false;
        private const byte DEFAULT_BYTE_VALUE = 0;
        private char DEFAULT_CHAR_VALUE = char.MinValue;
        private DateTime DEFAULT_DATETIME_VALUE = DateTime.MinValue;

        public string GetString(object PossibleString)
        {
            try
            {
                if (((SqlString)PossibleString).IsNull)
                {
                    return DEFAULT_STRING_VALUE;
                }
                else
                {
                    return PossibleString.ToString();
                }
            }
            catch
            {
                return DEFAULT_STRING_VALUE;
            }
        }

        public char GetChar(object PossibleChar)
        {
            try
            {
                var val = char.Parse(PossibleChar.ToString());
                return val;
            }
            catch
            {
                return DEFAULT_CHAR_VALUE;
            }
        }

        public uint GetUInt(object PossibleUInt)
        {
            try
            {
                var val = uint.Parse(PossibleUInt.ToString());
                return val;
            }
            catch
            {
                return DEFAULT_UINT_VALUE;
            }
        }

        public int GetInt(object PossibleInt)
        {
            try
            {
                var val = int.Parse(PossibleInt.ToString());
                return val;
            }
            catch
            {
                return DEFAULT_INT_VALUE;
            }
        }

        public long GetLong(object PossibleLong)
        {
            try
            {
                var val = long.Parse(PossibleLong.ToString());
                return val;
            }
            catch
            {
                return DEFAULT_LONG_VALUE;
            }
        }

        public double GetDouble(object PossibleDouble)
        {
            try
            {
                var val = double.Parse(PossibleDouble.ToString());
                return val;
            }
            catch
            {
                return DEFAULT_DOUBLE_VALUE;
            }
        }

        public bool GetBoolean(object PossibleBoolean)
        {
            try
            {
                var val = bool.Parse(PossibleBoolean.ToString());
                return val;
            }
            catch
            {
                return DEFAULT_BOOLEAN_VALUE;
            }
        }

        public DateTime GetDateTime(object PossibleDateTime)
        {
            try
            {
                var val = DateTime.Parse(PossibleDateTime.ToString());
                return val;
            }
            catch
            {
                return DateTime.MinValue;
            }
        }

        public byte GetByte(object PossibleByte)
        {
            try
            {
                var val = byte.Parse(PossibleByte.ToString());
                return val;
            }
            catch
            {
                return DEFAULT_BYTE_VALUE;
            }
        }

        public short GetShort(object PossibleShort)
        {
            try
            {
                var val = short.Parse(PossibleShort.ToString());
                return val;
            }
            catch
            {
                return DEFAULT_SHORT_VALUE;
            }
        }

        public object GetObject(object PossibleObject)
        {
            return PossibleObject;
        }
    }
}
