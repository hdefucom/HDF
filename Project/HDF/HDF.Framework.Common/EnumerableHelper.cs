using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDF.Framework.Common
{
    public static class EnumerableHelper
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> soures)
        {
            return soures == default || soures.Count() <= 0;
        }


        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }



        public static void Foreach<T>(this IEnumerable<T> soures, Action<T> act)
        {
            if (soures == default)
                throw new ArgumentNullException(nameof(soures));
            if (act == default)
                throw new ArgumentNullException(nameof(act));

            foreach (var item in soures)
            {
                act.Invoke(item);
            }
        }







    }
}
