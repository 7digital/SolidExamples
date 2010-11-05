using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace SOLID.Examples.SingleResponsibilityPrinciple
{
    public class OrderProcessingModule_VersionOne
    {
        public void Process(OrderStatusMessage orderStatusMessage)
        {
            // Get the connection string from configuration
            string connectionString =
                ConfigurationManager.ConnectionStrings["Main"]
                    .ConnectionString;

            Order order = null;

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // go get some data from the database
                order = fetchData(orderStatusMessage, connection);
            }

            // Apply the changes to the Order from the OrderStatusMessage
            updateTheOrder(order);

            // International orders have a unique set of business rules
            if (order.IsInternational)
            {
                processInternationalOrder(order);
            }

                // We need to treat larger orders in a special manner
            else if (order.LineItems.Count > 10)
            {
                processLargeDomesticOrder(order);
            }

                // Smaller domestic orders
            else
            {
                processRegularDomesticOrder(order);
            }

            // Ship the order if it's ready
            if (order.IsReadyToShip())
            {
                ShippingGateway gateway = new ShippingGateway();

                // Transform the Order object into a Shipment 
                ShipmentMessage message =
                    createShipmentMessageForOrder(order);
                gateway.SendShipment(message);
            }
        }

        private void processRegularDomesticOrder(Order order)
        {
            //implementation...
            ;
        }

        private void processLargeDomesticOrder(Order order)
        {
            //implementation...
           ;
        }

        private void processInternationalOrder(Order order)
        {
            //implementation...
            ;
        }

        private void updateTheOrder(Order order)
        {
            //implementation...
            ;
        }

        private Order fetchData(OrderStatusMessage message, SqlConnection connection)
        {
           return new Order();
        }

        private ShipmentMessage createShipmentMessageForOrder(Order order)
        {
            return new ShipmentMessage();
        }
    }

}
    public class OrderStatusMessage
    {
    }

    public class Order  
    {
        public bool IsInternational;
        public List<object> LineItems ;

        public bool IsReadyToShip()
        {
            throw new NotImplementedException();
        }
    }

    public class ShipmentMessage    
    {
    }

    public class ShippingGateway
    {
        public void SendShipment(ShipmentMessage message)
        {
            throw new NotImplementedException();
        }
    }