using PortaCapena.OdooJsonRpcClient;
using Warehouse.Core;

namespace Odoo.Warehouse.SDK
{
    public class OdooUser : IUser
    {
        private readonly OdooClient _client;

        public OdooUser(OdooClient client)
        {
            _client = client;
        }
    }
}
