using System.Collections.Generic;
using System.Threading.Tasks;
using PortaCapena.OdooJsonRpcClient;
using System.Linq;
using Warehouse.Core;

namespace Odoo.Warehouse.SDK
{
    public class OdooReceptions : IReceptions
    {
        private readonly OdooClient _client;
        private readonly IOdooRepository<OdooStockPickingDto> _repository;

        public OdooReceptions(OdooClient client)
            : this(client, new OdooRepository<OdooStockPickingDto>(client.Config))
        {
        }

        public OdooReceptions(
            OdooClient client,
            IOdooRepository<OdooStockPickingDto> repository)
        {
            _client = client;
            _repository = repository;
        }

        public async Task<IList<IReception>> ToListAsync()
        {
            var receptions = await _repository.Query().ToListAsync();
            return receptions.Value.Select(
                reception => new OdooReception(_client, reception)
            ).ToList<IReception>();
        }
    }
}
