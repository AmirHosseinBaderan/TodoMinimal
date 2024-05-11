namespace Server.Api.Abstractions;

public interface IResponse
{
    public bool Status { get; set; }

    public int Code { get; set; }

    public string Message { get; set; }

    public object Result { get; set; }

    public IResponse Success(object result, string message = "");

    public IResponse Faild(int code, string message);

    public IResponse Exception();
}

public class Response : IResponse
{
    public bool Status { get; set; }
    public int Code { get; set; }
    public string Message { get; set; } = null!;
    public object Result { get; set; } = null!;

    public IResponse Exception()
        => new Response
        {
            Code = 500,
            Result = new(),
            Status = false,
            Message = "Internal Server Error",
        };

    public IResponse Faild(int code, string message)
        => new Response
        {
            Code = code,
            Result = new(),
            Status = false,
            Message = message,
        };

    public IResponse Success(object result, string message = "")
        => new Response
        {
            Code = 200,
            Message = message,
            Result = result,
            Status = true,
        };
}