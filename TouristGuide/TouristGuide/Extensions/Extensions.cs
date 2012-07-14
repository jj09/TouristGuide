using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace TouristGuide
{
    public static class Extensions
    {
        public static IOrderedQueryable<TSource> OrderByWithDirection<TSource, TKey>
                      (this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector,
                       bool descending)
        {
            return descending ? source.OrderByDescending(keySelector)
                              : source.OrderBy(keySelector);
        }
    }
}
