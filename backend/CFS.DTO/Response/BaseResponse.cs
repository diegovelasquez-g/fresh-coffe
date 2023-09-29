namespace CFS.DTO.Response;

public class BaseResponse<T>
{
    public T? Data { get; set; }
    public string? Message { get; set; }
}