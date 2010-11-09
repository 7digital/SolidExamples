namespace SevenDigital.OCP.v3_option2
{
    public class OrderService
    {
        private readonly OrderRepository _orderRepository;

        public OrderService(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public virtual bool SaveOrder(Order order)
        {
            if (order.IsValid)
            {
                _orderRepository.Save(order);
            }
            return true;
        }
    }
}