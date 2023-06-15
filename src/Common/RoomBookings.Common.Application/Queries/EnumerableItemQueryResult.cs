using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookings.CommonQueries
{
    public class EnumerableItemQueryResult<T> : QueryResult, IQueryResult
    {
        public IEnumerable<T> Items { get; }

        private EnumerableItemQueryResult()
        {
        }

        public EnumerableItemQueryResult(IEnumerable<T> items)
        {
            Items = items;
            Success = true;
        }

        public static EnumerableItemQueryResult<T> Error(string errorMessage = "")
        {
            return new EnumerableItemQueryResult<T>
            {
                Success = false,
                ErrorMessage = errorMessage
            };
        }
    }

    public class EnumerableItemQueryResult
    {
        public static EnumerableItemQueryResult<T> Ok<T>(IEnumerable<T> items)
        {
            return new EnumerableItemQueryResult<T>(items);
        }
    }
}
