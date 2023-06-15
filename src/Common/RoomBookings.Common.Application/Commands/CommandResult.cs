namespace RoomBookings.Common.Application.Commands
{
    public class CommandResult<T> : CommandResult
    {
        public T Content { get; }

        private CommandResult()
        {
        }

        public CommandResult(T content)
        {
            Content = content;
            Success = true;
        }

        public static CommandResult<T> Error(string errorMessage = "")
        {
            var result =  new CommandResult<T> 
            { 
                Success = false, 
            };

            result.ErrorMessages.Add(errorMessage);

            return result;
        }

        public static CommandResult<T> Error(IEnumerable<string> errorMessages)
        {
            var result = new CommandResult<T>
            {
                Success = false,
            };

            result._errorMessages.AddRange(errorMessages);

            return result;
        }
    }

    public class CommandResult
    {
        public bool Success { get; protected set; }

        protected List<string> _errorMessages = new List<string>();
        public ICollection<string> ErrorMessages => _errorMessages;

        public static CommandResult Ok()
        {
            return new CommandResult()
            {
                Success = true
            };
        }

        public static CommandResult<T> Ok<T>(T content)
        {
            return new CommandResult<T>(content);
        }

        public static CommandResult Error(string errorMessage = "")
        {
            var result = new CommandResult
            {
                Success = false,
            };

            result.ErrorMessages.Add(errorMessage);

            return result;
        }

        public static CommandResult Error(IEnumerable<string> errorMessages)
        {
            var result = new CommandResult
            {
                Success = false,
            };

            result._errorMessages.AddRange(errorMessages);

            return result;
        }
    }
}
