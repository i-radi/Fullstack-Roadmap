using System;
using System.Linq;
using System.Linq.Expressions;

namespace Linq.If
{
    public static class OrdersExtensions
    {
        public static IOrderedQueryable<TSource> OrderByIf<TSource, TKey>(this IQueryable<TSource> query, bool condition, Expression<Func<TSource, TKey>> orderByExpression)
        {
            if (condition == true)
                return query.OrderBy(orderByExpression);
            else
                return (IOrderedQueryable<TSource>)query;
        }


        public static IOrderedQueryable<TSource> OrderByDescendingIf<TSource, TKey>(this IQueryable<TSource> query, bool condition, Expression<Func<TSource, TKey>> orderByExpression)
        {
            if (condition == true)
                return query.OrderByDescending(orderByExpression);
            else
                return (IOrderedQueryable<TSource>)query;
        }

        public static IOrderedQueryable<TSource> ThenByIf<TSource, TKey>(this IOrderedQueryable<TSource> query, bool condition, Expression<Func<TSource, TKey>> orderByExpression)
        {
            if (condition == true)
                return query.ThenBy(orderByExpression);
            else
                return query;
        }


        public static IOrderedQueryable<TSource> ThenByDescendingIf<TSource, TKey>(this IOrderedQueryable<TSource> query, bool condition, Expression<Func<TSource, TKey>> orderByExpression)
        {
            if (condition == true)
                return query.ThenByDescending(orderByExpression);
            else
                return query;
        }
    }
}
