using AnyCompany.Store;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace AnyCompany
{
    public static class CustomerRepository
    {
        private static Store.IAnyCompanyDBContext anyCompanyDBContext;

        public static void SetContext(Store.IAnyCompanyDBContext context)
        {
            anyCompanyDBContext = context;
        }

        public static Customer Load(int customerId)
        {
            return anyCompanyDBContext.Customers.FirstOrDefault(c => c.CustomerId == customerId);
        }
    }
}
