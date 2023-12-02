namespace API.Utilities;

public class RepositoryResult<TData>
{
    public bool IsSuccess { get; set; }
    public string? Exception { get; set; }
    public TData? Data { get; set; } 
}
