using System;
using System.Configuration;
using System.Data.SqlClient;

namespace AnyCompany
{
    public static class CustomerRepository
    {
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["AnyCompanyDB"].ConnectionString;

        public static Customer Load(int customerId)
        {
            Customer customer = new Customer();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Customer WHERE CustomerId = " + customerId,
                    connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    customer.Name = reader["Name"].ToString();
                    customer.DateOfBirth = DateTime.Parse(reader["DateOfBirth"].ToString());
                    customer.Country = reader["Country"].ToString();
                }

                connection.Close();

                return customer;
            }
        }
    }
}
