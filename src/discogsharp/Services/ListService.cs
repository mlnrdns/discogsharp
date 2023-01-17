using discogsharp.Domain;
using discogsharp.Utils;

namespace discogsharp.Services
{
    public class ListService : IListService
    {
        private readonly Connection connection;

        public ListService(Connection connection)
        {
            this.connection = connection;
        }

        public async Task<IEnumerable<PaginatedResponse<DiscogsListForUser>>> GetAllByUserAsync(string username, CancellationToken cancellationToken = default)
            => await this.connection.SendPagedRequestAsync<DiscogsListForUser>(HttpMethod.Get, $"users/{username}/lists", cancellationToken);

        public async Task<DiscogsList> GetByIdAsync(long id, CancellationToken cancellationToken = default)
            => await this.connection.SendRequestAsync<DiscogsList>(HttpMethod.Get, $"lists/{id}", cancellationToken);

        public async Task<PaginatedResponse<DiscogsListForUser>> GetByUserAsync(
                            string username,
            int page = Constants.DefaultPage,
            int perPage = Constants.DefaultPerPage,
            CancellationToken cancellationToken = default)
            => await this.connection.SendPagedRequestAsync<DiscogsListForUser>(HttpMethod.Get, $"users/{username}/lists", new Dictionary<string, string>()
            {
                [Constants.PageQueryParameterName] = $"{page}",
                [Constants.PerPageQueryParameterName] = $"{perPage}"
            }, cancellationToken);
    }
}
