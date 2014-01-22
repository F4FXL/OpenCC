using System;

namespace OpenCC.Common
{
    /// <summary>
    /// BCD converter.
    /// </summary>
    public static class BCDConverter
    {
        public static uint BCDtoDecimal(this uint bcd)
        {
            uint result = 0;
            uint multiplier = 1;
            uint value = bcd;

            while (value > 0)
            {
                uint digit = value & 0xF;
                value >>= 4;
                result += multiplier * digit;
                multiplier *= 10;
            }
            return result;
        }
    }
}

