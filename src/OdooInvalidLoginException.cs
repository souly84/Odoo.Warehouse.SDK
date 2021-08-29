using System;
using PortaCapena.OdooJsonRpcClient.Result;

namespace Odoo.Warehouse.SDK
{
    public class OdooInvalidLoginException<T> : Exception
    {
        public OdooResult<T> LoginResult{ get; }

        public OdooInvalidLoginException(string message, OdooResult<T> result)
            : base($"{message}. {result.Error}")
        {
            LoginResult = result;
        }
    }
}
