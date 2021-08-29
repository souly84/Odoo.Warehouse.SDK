using PortaCapena.OdooJsonRpcClient;
using Warehouse.Core;

namespace Odoo.Warehouse.SDK
{
    public class OdooWarehouse : IWarehouse
    {
        private readonly OdooClient _client;

        public OdooWarehouse(OdooClient client)
        {
            _client = client;
        }

        public IReceptions Receptions => new OdooReceptions(_client);
    }
}
