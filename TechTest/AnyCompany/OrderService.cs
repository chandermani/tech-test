namespace AnyCompany
{
    public class OrderService
    {
        private readonly ICustomerRepositoryShim customerRepository;
        private readonly IOrderRepository orderRepository;

        public OrderService(ICustomerRepositoryShim customerRepository, 
                            IOrderRepository orderRepository)
        {
            this.customerRepository = customerRepository;
            this.orderRepository = orderRepository;
        }

        public bool PlaceOrder(Order order, int customerId)
        {
            Customer customer = customerRepository.Load(customerId);

            if (order.Amount == 0)
                return false;

            order.VAT = new VatCalculator().CalculateVat(customer);
            
            orderRepository.Save(order);

            return true;
        }
    }
}
