using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hgSoftware.DomainServices
{
    internal static class Extensions
    {
        public static IEnumerable<T> Reverse<T>(this IEnumerable<T> items)
        {
            IList<T> list = (IList<T>)items;
            if (list == null)
                yield return default(T);
            for (int i = list.Count - 1; i >= 0; i--)
            {
                yield return list[i];
            }
        }
    }
}
