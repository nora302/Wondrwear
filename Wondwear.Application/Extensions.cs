

namespace Wondwear.Application;

public static class Extensions
{
    public static async Task<PaginationResponseDTO<T>> PaginateAsync<T>(
    this IEnumerable<T> source,
    int page = 1,
    int size = 10
)
    where T : class
    {
        if (page <= 0)
        {
            page = 1;
        }

        if (size <= 0)
        {
            size = 10;
        }
        var total = await CountAsync(source);
        var pages = (int)Math.Ceiling((decimal)total / size);
        var result = source.Skip((page - 1) * size).Take(size).ToList();

        return new PaginationResponseDTO<T>(Values: result, Pages: pages);
    }
    public static async Task<PaginationResponseDTO<T>> PaginateAsync<T>(
    this IQueryable<T> source,
    int page = 1,
    int size = 10
)
    where T : class
    {
        if (page <= 0)
        {
            page = 1;
        }

        if (size <= 0)
        {
            size = 10;
        }
        var total = await CountAsync(source);
        var pages = (int)Math.Ceiling((decimal)total / size);
        var result = source.Skip((page - 1) * size).Take(size).ToList();

        return new PaginationResponseDTO<T>(Values: result, Pages: pages);
    }
    private static async Task<int> CountAsync<T>(IEnumerable<T> source)
    {
        var count = 0;
        foreach (var item in source)
        {
            count++;
            await Task.Yield();
        }
        return count;
    }
    private static async Task<int> CountAsync<T>(IQueryable<T> source)
    {
        var count = 0;
        foreach (var item in source)
        {
            count++;
            await Task.Yield();
        }
        return count;
    }
    
}
