using MapsterMapper;
using MediatR;

namespace Todo.Server.Api.Abstractions;

public interface IEndpoint<TReuest, TResponse>
{
    void MapEndpoint(IEndpointRouteBuilder app);

    Task<TResponse> HandlerAsync([AsParameters] TReuest request, IMapper mapper, IMediator mediator);
}
