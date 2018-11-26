using AnyCompany.Store;
using System.Configuration;
using System.Data.SqlClient;

namespace AnyCompany
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IAnyCompanyDBContext anyCompanyDBContext;

        public OrderRepository(IAnyCompanyDBContext anyCompanyDBContext)
        {
            this.anyCompanyDBContext = anyCompanyDBContext;
        }

        public void Save(Order order)
        {
            anyCompanyDBContext.Orders.Add(order);
        }
    }
}
