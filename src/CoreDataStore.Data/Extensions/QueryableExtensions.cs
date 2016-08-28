using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CoreDataStore.Data.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, IEnumerable<SortModel> sortModels)
        {
            var expression = source.Expression;
            int count = 0;
            foreach (var item in sortModels)
            {
                if (string.IsNullOrEmpty(item.SortColumn))
                {
                    continue;
                }

                var parameter = Expression.Parameter(typeof(T), "x");
                var selector = Expression.PropertyOrField(parameter, item.SortColumn);
                var method = string.Equals(item.SortOrder, "desc", StringComparison.OrdinalIgnoreCase) ?
                    (count == 0 ? "OrderByDescending" : "ThenByDescending") :
                    (count == 0 ? "OrderBy" : "ThenBy");
                expression = Expression.Call(typeof(Queryable), method,
                    new Type[] { source.ElementType, selector.Type },
                    expression, Expression.Quote(Expression.Lambda(selector, parameter)));
                count++;
            }
            return count > 0 ? source.Provider.CreateQuery<T>(expression) : source;
        }
    }

    public class SortModel
    {
       public string SortColumn { get; set; }

       public string SortOrder { get; set; }
    }

}
