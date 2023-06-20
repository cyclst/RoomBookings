using System.Reflection;
using MediatR;
using Microsoft.Extensions.Logging;

namespace RoomBookings.Common.Application.Behaviours;

//Credit: https://codewithmukesh.com/blog/mediatr-pipeline-behaviour/
//Also have a look at https://github.com/jasontaylordev/CleanArchitecture/tree/main/src/Application/Common/Behaviours
public sealed class LoggingPipelineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly ILogger<LoggingPipelineBehaviour<TRequest, TResponse>> _logger;
    public LoggingPipelineBehaviour(ILogger<LoggingPipelineBehaviour<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        //Request
        _logger.LogInformation($"Handling {typeof(TRequest).Name}");
        Type myType = request.GetType();
        IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
        foreach (PropertyInfo prop in props)
        {
            object propValue = prop.GetValue(request, null);
            _logger.LogDebug("{Property} : {@Value}", prop.Name, propValue);
        }
        var response = await next();
        //Response
        _logger.LogDebug($"Handled {typeof(TResponse).Name}");
        return response;
    }
}
