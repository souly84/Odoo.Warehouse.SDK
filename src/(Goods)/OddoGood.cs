using PortaCapena.OdooJsonRpcClient;
using Warehouse.Core;

namespace Odoo.Warehouse.SDK
{
    public class OddoGood : IGood
    {
        private readonly OdooClient _client;
        private readonly OdooStockGoodDto _odooGood;

        public OddoGood(
            OdooClient client,
            OdooStockGoodDto odooGood)
        {
            _client = client;
            _odooGood = odooGood;
        }
    }
}
