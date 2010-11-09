namespace SevenDigital.OCP.v1
{
    public class OrderService
    {
        private readonly OrderRepository _orderRepository;

        public OrderService(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public bool SaveOrder(Order order)
        {
            if (order.IsValid)
            {
                _orderRepository.Save(order);
            }
            return true;
        }
    }
}