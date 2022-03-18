using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStringFormat
{
    internal static class Extensions
    {
        public static int IndexOf(this StringBuilder stringBuilder, char c)
        {
            for (int i = 0; i < stringBuilder.Length; i++)
            {
                if (stringBuilder[i] == c)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
