namespace Server.Api.Abstractions;

public interface IEndpointHandler<TRequest, TResponse>
{
    Task<TResponse> HandlerAsync(TRequest request, IMapper mapper, IMediator mediator);
}
