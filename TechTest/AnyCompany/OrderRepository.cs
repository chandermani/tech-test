using System.Configuration;
using System.Data.SqlClient;

namespace AnyCompany
{
    public class OrderRepository : IOrderRepository
    {
        private readonly string connectionString;

        public OrderRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Save(Order order)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO Orders VALUES (@OrderId, @Amount, @VAT)", connection);

                command.Parameters.AddWithValue("@OrderId", order.OrderId);
                command.Parameters.AddWithValue("@Amount", order.Amount);
                command.Parameters.AddWithValue("@VAT", order.VAT);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
    }
}
