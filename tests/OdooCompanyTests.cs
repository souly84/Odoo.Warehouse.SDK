using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Odoo.Warehouse.SDK.Extensions;
using PortaCapena.OdooJsonRpcClient;
using PortaCapena.OdooJsonRpcClient.Models;
using Xunit;
using Xunit.Abstractions;

namespace Odoo.Warehouse.SDK.Tests
{
    public class OdooCompanyTests
    {
        private static string _odooCompanyUri = ConfigurationManager.AppSettings["companyUri"];
        private static string _odooDb = ConfigurationManager.AppSettings["database"];
        private string _userName = ConfigurationManager.AppSettings["userLogin"];
        private string _userPassword = ConfigurationManager.AppSettings["password"];
        private OdooCompany _odooCompany = new OdooCompany(
            _odooCompanyUri,
            _odooDb
        );
        private readonly ITestOutputHelper _output;

        public OdooCompanyTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public async Task SuccesfullLogin()
        {
            Assert.NotNull(
                await _odooCompany.LoginAsync(_userName, _userPassword)
            );
        }

        [Fact]
        public Task UnsuccesfullLogin()
        {
            return Assert.ThrowsAsync<OdooInvalidLoginException<int>>(
                () => _odooCompany.LoginAsync("wrongEmail@gmail.com", "wrongPassword")
            );
        }

        [Fact]
        public async Task GetReceptions()
        {
            await _odooCompany.LoginAsync(_userName, _userPassword);
            Assert.NotEmpty(
                await _odooCompany.Warehouse.Receptions.ToListAsync()
            );
        }

        [Fact]
        public async Task GetReceptionGoods()
        {
            await _odooCompany.LoginAsync(_userName, _userPassword);
            var receptions = await _odooCompany.Warehouse.Receptions.ToListAsync();
            Assert.NotEmpty(
                await receptions.First().Goods.ToListAsync()
            );
        }

        [Fact(Skip = "Only for manual run")]
        public async Task ReceptionsDto()
        {
            var client = new OdooClient(
                new OdooConfig(
                   _odooCompanyUri,
                   _odooDb,
                   _userName,
                   _userPassword
                )
            );
            await client.LoginAsync();
            _output.WriteLine(await client.DotNetModel(new OdooStockGoodDto()));
        }
    }
}
