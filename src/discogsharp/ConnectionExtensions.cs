using discogsharp.Services;

namespace discogsharp;

public static class ConnectionExtensions
{
    public static ICollectionService CreateCollectionService(this Connection connection)
    {
        return new CollectionService(connection);
    }

    public static IDatabaseService CreateDatabaseService(this Connection connection)
    {
        return new DatabaseService(connection);
    }

    public static IImageService CreateImageService(this Connection connection)
    {
        return new ImageService(connection);
    }
}
