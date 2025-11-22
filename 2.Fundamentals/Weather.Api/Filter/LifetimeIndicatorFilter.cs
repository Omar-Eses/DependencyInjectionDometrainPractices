using Microsoft.AspNetCore.Mvc.Filters;
using Weather.Api.Service;

namespace Weather.Api.Filter;

public class LifetimeIndicatorFilter : IActionFilter
{
    private readonly IdGenerator _idGenerator;
    private readonly ILogger<LifetimeIndicatorFilter> _logger;

    public LifetimeIndicatorFilter(IdGenerator idGenerator, ILogger<LifetimeIndicatorFilter> logger)
    {
        _idGenerator = idGenerator;
        _logger = logger;
    }


    public void OnActionExecuting(ActionExecutingContext context)
    {
        var id = _idGenerator.Id;
        _logger.LogInformation("{OnActionExecutingName} id was {Guid}.", nameof(OnActionExecuting), id);
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        var id = _idGenerator.Id;
        _logger.LogInformation("{OnActionExecuted} id was {Guid}.", nameof(OnActionExecuted), id);
    }
}