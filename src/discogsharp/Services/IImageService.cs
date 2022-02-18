namespace discogsharp.Services;

public interface IImageService
{
    Task<byte[]> GetAsync(string uri, CancellationToken cancellationToken = default);
}
