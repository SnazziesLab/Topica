namespace Topica.Server.Data
{
    public record PaginatedResponse<T>(T[] data, int page, int pageSize, int total);

}
