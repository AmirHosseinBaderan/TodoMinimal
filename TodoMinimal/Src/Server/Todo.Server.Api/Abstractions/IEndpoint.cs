using MapsterMapper;
using MediatR;

namespace Todo.Server.Api.Abstractions;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}

public interface IEndpointHandler<TRequest, TResponse>
{
    Task<TResponse> HandlerAsync(TRequest request, IMapper mapper, IMediator mediator);
}
