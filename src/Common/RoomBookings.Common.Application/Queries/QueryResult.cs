namespace RoomBookings.CommonQueries
{
    public class QueryResult
    {
        public bool Success { get; protected set; }
        public string ErrorMessage { get; protected set; } = "";

        public static QueryResult Ok()
        {
            return new QueryResult()
            {
                Success = true
            };
        }

        public static QueryResult Error(string errorMessage = "")
        {
            return new QueryResult
            {
                Success = false,
                ErrorMessage = errorMessage
            };
        }
    }
}
