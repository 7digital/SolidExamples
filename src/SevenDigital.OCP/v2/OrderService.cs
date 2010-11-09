namespace SevenDigital.OCP.v2
{
    public class OrderService
    {
        private readonly OrderRepository _orderRepository;
        private readonly EmailService _emailService;
        private readonly ConfirgurationService _confirgurationService;

        public OrderService(OrderRepository orderRepository, EmailService emailService, ConfirgurationService confirgurationService)
        {
            _orderRepository = orderRepository;
            _emailService = emailService;
            _confirgurationService = confirgurationService;
        }

        public bool SaveOrder(Order order)
        {
            if (order.IsValid)
            {
                _orderRepository.Save(order);
            }
            if (_confirgurationService.SendEmailConfirmation)
            {
                _emailService.SendConfirmation(order);
            }
            return true;
        }
    }
}