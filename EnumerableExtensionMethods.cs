using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ13
{
    
    internal static class EnumerableExtensionMethods
    {
        /// <summary>
        /// метод расширения, принимающий значение Х от 1 до 100 и 
        /// возвращающий заданное количество процентов от выборки с 
        /// округлением количества элементов в большую сторону.
        /// </summary>
        public static IEnumerable<T> Top<T>(this IEnumerable<T> source, int percent)
        {
            if (!(percent < 100 && percent >= 0)) throw new ArgumentException($"Value must be more than 0 and less than 100. {percent} is uncorrect.");
            
            foreach (var item in source)
            {
                if (!(item is int) || (item is null)) throw new ArgumentException($"Use integer array only.");
            }

            int IntegerPart = source.Count() * percent / 100;
            double FullNumber = source.Count() * percent / 100.00;
            if ((FullNumber - IntegerPart) * 100 > 50) IntegerPart += 1;

            return (IEnumerable<T>)source.OrderByDescending(n => Convert.ToInt32(n)).Take(IntegerPart);
        }

        public static IEnumerable<T> Top<T>(this IEnumerable<T> source, int percent, Func<T, int> predicate)
        {
            if (!(percent < 100 && percent >= 0)) throw new ArgumentException($"Value must be more than 0 and less than 100. {percent} is uncorrect.");

            int IntegerPart = source.Count() * percent / 100;
            double FullNumber = source.Count() * percent / 100.00;
            if ((FullNumber - IntegerPart) * 100 > 50) IntegerPart += 1;

            return (IEnumerable<T>)source.OrderByDescending(n => predicate(n)).Take(IntegerPart);
        }
    }
}
