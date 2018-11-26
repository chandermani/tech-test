using AnyCompany.Store;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace AnyCompany
{
    public static class CustomerRepository
    {
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["AnyCompanyDB"].ConnectionString;

        public static Customer Load(int customerId)
        {
            return new AnyCompanyDBContext().Customers.FirstOrDefault(c => c.CustomerId == customerId);
        }
    }
}
