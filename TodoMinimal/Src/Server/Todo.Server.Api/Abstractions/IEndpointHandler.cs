namespace Server.Api.Abstractions;

public interface IEndpointHandler<TRequest, TResponse>
{
    Task<TResponse> HandlerAsync(HttpContext context, TRequest request, IMapper mapper, IMediator mediator);
}
