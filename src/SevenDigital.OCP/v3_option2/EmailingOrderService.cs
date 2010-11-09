namespace SevenDigital.OCP.v3_option2
{
    public class EmailingOrderService
    {
        private readonly EmailService _emailService;
        private readonly OrderService _orderService;

        public EmailingOrderService(EmailService emailService, OrderService orderService)
        {
            _emailService = emailService;
            _orderService = orderService;
        }

        public bool SaveOrder(Order order)
        {
            if (_orderService.SaveOrder(order))
            {
                _emailService.SendConfirmation(order);
            }
            return true;
        }
    }
}