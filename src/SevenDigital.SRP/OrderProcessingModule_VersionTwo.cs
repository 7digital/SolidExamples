using System;

namespace SOLID.Examples.SingleResponsibilityPrinciple
{
    /// <summary>
    /// An example of the Chain Of Responsibility Pattern
    /// http://en.wikipedia.org/wiki/Chain-of-responsibility_pattern
    /// </summary>
    public class OrderProcessingModule_VersionTwo
    {
        private IOrderHandler[] _handlers;

        public OrderProcessingModule_VersionTwo()
        {
            _handlers = new IOrderHandler[]
                            {
                                new InternationalOrderHandler(),
                                new SmallDomesticOrderHandler(),
                                new LargeDomesticOrderHandler(),
                            };
        }

        public void Process(OrderStatusMessage orderStatusMessage,
                            Order order)
        {
            // Apply the changes to the Order from the OrderStatusMessage
            updateTheOrder(order);

            // Find the first IOrderHandler that "knows" how
            // to process this Order
            IOrderHandler handler =
                Array.Find(_handlers, h => h.CanProcess(order));

            handler.ProcessOrder(order);
        }

        private void updateTheOrder(Order order)
        {
        }
    }

    public class LargeDomesticOrderHandler : IOrderHandler
    {
        public void ProcessOrder(Order order)
        {
            //implemenation...
            ;
        }

        public bool CanProcess(Order order)
        {
            //implemenation...
            return true;
        }
    }

    public class SmallDomesticOrderHandler  : IOrderHandler
    {
        public void ProcessOrder(Order order)
        {
            //implemenation...
            ;
        }

        public bool CanProcess(Order order)
        {
            //implemenation...
            return true;
        }
    }

    public class InternationalOrderHandler : IOrderHandler
    {
        public void ProcessOrder(Order order)
        {
            //implemenation...
            ;
        }

        public bool CanProcess(Order order)
        {
            //implemenation...
            return true;
        }
    }

    public interface IOrderHandler
    {
        void ProcessOrder(Order order);
        bool CanProcess(Order order);
    }
}