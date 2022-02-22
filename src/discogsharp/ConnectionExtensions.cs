using discogsharp.Services;

namespace discogsharp;

public static class ConnectionExtensions
{
    public static ICollectionService CreateCollectionService(this Connection connection) => new CollectionService(connection);

    public static IDatabaseService CreateDatabaseService(this Connection connection) => new DatabaseService(connection);

    public static IImageService CreateImageService(this Connection connection) => new ImageService(connection);

    public static IWantService CreateWantService(this Connection connection) => new WantService(connection);
}
