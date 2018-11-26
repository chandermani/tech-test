using AnyCompany.Queries;
using System.Collections.Generic;

namespace AnyCompany
{
    public class OrderService
    {
        private readonly ICustomerRepositoryShim customerRepository;
        private readonly IOrderRepository orderRepository;
        private readonly CustomerOrdersQuery customerOrdersQuery;
        private readonly IVatCalculator vatCalculator;

        public OrderService(ICustomerRepositoryShim customerRepository, 
                            IOrderRepository orderRepository,
                            CustomerOrdersQuery customerOrdersQuery,
                            IVatCalculator vatCalculator)
        {
            this.customerRepository = customerRepository;
            this.orderRepository = orderRepository;
            this.customerOrdersQuery = customerOrdersQuery;
            this.vatCalculator = vatCalculator;
        }

        public bool PlaceOrder(Order order, int customerId)
        {
            // Currently not handling what happens when customer not found.
            Customer customer = customerRepository.Load(customerId);

            // Improvement - Can move into its own validation class.
            if (order.Amount == 0)
                return false;

            order.VAT = vatCalculator.CalculateVat(customer);

            order.CustomerId = customer.CustomerId;
            
            orderRepository.Save(order);

            return true;
        }

        public List<Customer> GetAllCustomerOrders()
        {
            return customerOrdersQuery.Query();
        }
    }
}
