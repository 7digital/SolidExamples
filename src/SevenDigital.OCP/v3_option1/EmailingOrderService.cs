namespace SevenDigital.OCP.v3_option1
{
    public class EmailingOrderService : OrderService
    {
        private readonly EmailService _emailService;

        public EmailingOrderService(EmailService emailService, OrderRepository orderRepository)
            : base(orderRepository)
        {
            _emailService = emailService;
        }

        public override bool SaveOrder(Order order)
        {
            if (base.SaveOrder(order))
            {
                _emailService.SendConfirmation(order);
            }
            return true;
        }
    }
}