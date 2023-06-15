using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookings.CommonQueries
{
    public class ItemQueryResult<T> : QueryResult
    {
        public T Item { get; }

        private ItemQueryResult()
        {
        }

        public ItemQueryResult(T item)
        {
            Item = item;
            Success = true;
        }

        public static ItemQueryResult<T> Error(string errorMessage = "")
        {
            return new ItemQueryResult<T>
            {
                Success = false,
                ErrorMessage = errorMessage
            };
        }
    }

    public class ItemQueryResult
    {
        public static ItemQueryResult<T> Ok<T>(T item)
        {
            return new ItemQueryResult<T>(item);
        }
    }
}
