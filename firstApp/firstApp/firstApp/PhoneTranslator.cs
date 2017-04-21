using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    class PhoneTranslator
    {
        static readonly string[] digits =
        {
            "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ"
        };

        public static string ToNumber(string raw)
        {
            if (string.IsNullOrWhiteSpace(raw)) return null;

            raw = raw.ToUpperInvariant();

            var number = new StringBuilder();
            foreach(var no in raw)
            {
                if ("-0123456789".Contains(no.ToString())) number.Append(no);
                else
                {
                    var translated = TranslateToNumber(no);
                    if (translated != null) number.Append(translated);
                    else return null;
                }
            }

            return number.ToString();
        }

        static int? TranslateToNumber(char c)
        {
            for(int i = 0; i < digits.Length; i++)
            {
                if (digits[i].Contains(c.ToString())) return 2 + i;
            }
            return null;
        }
    }
}
