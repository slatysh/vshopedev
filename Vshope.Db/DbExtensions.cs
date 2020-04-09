using System;
using System.Linq;
using System.Linq.Expressions;
using Vshope.Model.Model.Common;

namespace Vshope.Db
{
    public static class DbExtensions
    {
        public static IQueryable<T> WhereIsNotDeleted<T>(this IQueryable<T> source,
            Expression<Func<T, bool>> predicate = null) where T : EntityApp
        {
            var query = source.Where(x => !x.IsDeleted);
            if (predicate == null)
            {
                return query;
            }

            return query.Where(predicate);
        }
    }
}
