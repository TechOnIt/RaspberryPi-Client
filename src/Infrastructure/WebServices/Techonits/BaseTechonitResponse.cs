namespace TechOnIt.Infrastructure.WebServices.Techonits;

internal class BaseTechonitResponse<TData>
{
    public TData Data { get; set; }
    public int StatusCode { get; set; }
    public string[] Message { get; set; }
}