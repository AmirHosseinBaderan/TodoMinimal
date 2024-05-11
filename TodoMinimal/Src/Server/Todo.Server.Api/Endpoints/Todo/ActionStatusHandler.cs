using Application.Todo;

namespace Server.Api.Endpoints.Todo;

public static class TodoActionStatusHandler
{
    public static IResponse Handler(this TodoActionStatus status, object? result)
    {
        Response response = new();
        return status switch
        {
            TodoActionStatus.Success => response.Success(result ?? new()),
            TodoActionStatus.Faild => response.Faild(500, "Exception in action"),
            TodoActionStatus.NotFound => response.Faild(404, "Todo not found"),
            _ => response.Exception(),
        };
    }
}
