using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Vshope.Common;
using Vshope.Model.DTO.Common;

namespace Vshope.Application.Extension
{
    public static class QueryExtension
    {
        public static IQueryable<T> ApplyListRequestFilter<T>(this IQueryable<T> query, ListRequestDTO listRequestDTO,
            Func<string, Expression<Func<T, object>>> orderKeySelectorFromStringFunc)
        {
            if (!string.IsNullOrEmpty(listRequestDTO.SortBy) && listRequestDTO.Descending.HasValue)
            {
                var orderKeySelector = orderKeySelectorFromStringFunc(listRequestDTO.SortBy);
                if (listRequestDTO.Descending.Value)
                {
                    query = query.OrderByDescending(orderKeySelector);
                }
                else
                {
                    query = query.OrderBy(orderKeySelector);
                }
            }

            if (listRequestDTO.RowsPerPage == -1)
            {
                query = query.Take(ConstantsApp.REQUEST_LIST_MAX_COUNT);
            }
            else
            {
                query = query.Skip((listRequestDTO.Page - 1) * listRequestDTO.RowsPerPage)
                    .Take(listRequestDTO.RowsPerPage);
            }
            return query;
        }
    }
}
