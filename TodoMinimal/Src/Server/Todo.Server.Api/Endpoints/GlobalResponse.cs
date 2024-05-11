namespace Server.Api.Endpoints;

public static class GlobalResponse
{
    public static IResponse Success(this object result)
    {
        Response response = new();
        return response.Success(result);
    }
}
