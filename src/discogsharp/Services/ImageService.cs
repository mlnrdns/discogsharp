namespace discogsharp.Services;

public class ImageService : IImageService
{
    private readonly Connection connection;

    public ImageService(Connection connection)
    {
        this.connection = connection;
    }

    public async Task<byte[]> GetAsync(string uri, CancellationToken cancellationToken = default) => await this.connection.GetByteArrayAsync(uri, cancellationToken);
}
