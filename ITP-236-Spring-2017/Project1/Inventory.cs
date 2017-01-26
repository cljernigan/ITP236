using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{

    public class Part
    {
        public const string StudentName = "Christopher Jernigan";
        public string Name { get; set; }
        public int PartId { get; set; }

        public int UnitsSold
        {
            get
            {
                int total = 0;
                foreach (var part in SalesOrderParts)

                    total += part.Quantity;
                return total;
            }
        }

        public int QuantityOnHand { get; set; }
        public decimal CurrentValue { get; set; }

        public decimal AmountSold
        {
            get
            {
                decimal total = 0;
                foreach (var sop in SalesOrderParts)

                    total += sop.ExtendedPrice;
                return total;

            }
        }

        public decimal Price { get; set; }
        public List<SalesOrderPart> SalesOrderParts { get; set; }

        public Part(int partId, string name, decimal price)
        {
            PartId = partId;
            Name = name;
            Price = price;
            SalesOrderParts = new List<SalesOrderPart>();
        }

        public Part() : this(0, "", 0)
        {
        }

    }
    public class Shipment
    {
        public int ShipmentId { get; set; }
        public int SalesOrderNumber { get; set; }
        public DateTime ShipmentDate { get; set; }
        public SalesOrder SalesOrder { get; set; }
        public Shipment(int salesOrderNumber, DateTime shipmentDate)
        {
            SalesOrderNumber = salesOrderNumber;
            ShipmentDate = shipmentDate;
        }

        public Shipment() : this(-1, DateTime.Today)
        {
        }
    }
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public decimal TotalSales
        {
            get
            {
                decimal total = 0;
                foreach (var cust in SalesOrders)

                    total += cust.OrderTotal;
                return total;
            }

        }
        public decimal TotalCost
        {
            get
            {
                decimal total = 0;
                foreach (var cust in SalesOrders)

                    total += cust.OrderCost;
                return total;
            }

        }
        public decimal GrossProfit
        {
            get
            {
                return TotalSales - TotalCost;
            }

        }

        public List<SalesOrder> SalesOrders { get; set; }

        public void AddSalesOrder(object salesOrder)
        {
            SalesOrders.Add((SalesOrder)salesOrder);
        }

        public Customer(int customerId, string firstName, string lastName, string city, string state)
        {
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            City = city;
            State = state;
            SalesOrders = new List<SalesOrder>();
        }

        public Customer() : this(-1, "", "", "", "")
        {
        }
    }

    public class SalesOrder
    {
        public int SalesOrderNumber { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderTotal
        {
            get
            {
                decimal total = 0;
                foreach (var salitem in SalesOrderParts)

                    total += salitem.ExtendedPrice;
                return total;
            }
        }

        public decimal OrderCost
        {
            get
            {
                decimal total = 0;
                foreach (var salitem in SalesOrderParts)

                    total += salitem.ExtendedCost;
                return total;
            }
        }
        public decimal OrderProfit { get { return OrderTotal - OrderCost; } }
        public List<SalesOrderPart> SalesOrderParts { get; set; }
        public List<Shipment> Shipments { get; set; }

        public void AddSalesOrderPart(object salesOrderPart)
        {
            SalesOrderParts.Add((SalesOrderPart)salesOrderPart);
        }

        public SalesOrder(int salesOrderNumber, int customerId, DateTime orderDate)
        {
            SalesOrderNumber = salesOrderNumber;
            CustomerId = customerId;
            OrderDate = orderDate;

            SalesOrderParts = new List<SalesOrderPart>();
            Shipments = new List<Shipment>();
        }

        public SalesOrder() : this(-1, -1, DateTime.Today)
        {
        }


    }

    public class SalesOrderPart
    {
        public int SalesOrderPartId { get; set; }
        public int Quantity { get; set; }
        public int SalesOrderNumber { get; set; }
        public int PartId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitCost { get; set; }
        public Part Part { get; set; }
        public SalesOrder SalesOrder { get; set; }

        public decimal ExtendedCost { get { return UnitCost * Quantity; } }
        public decimal ExtendedPrice { get { return UnitPrice * Quantity; } }

        public decimal GrossProfit
        {
            get { return ExtendedPrice - ExtendedCost; }
        }

        public SalesOrderPart(int salesOrderPartId, int salesOrderNumber, int partId, int quantity, decimal unitPrice,
            decimal unitCost)
        {
            SalesOrderPartId = salesOrderPartId;
            SalesOrderNumber = salesOrderNumber;
            Quantity = quantity;
            UnitPrice = unitPrice;
            PartId = partId;
            UnitCost = unitCost;

        }

        public SalesOrderPart() : this(0, 0, 0, 0, 0, 0)
        {
        }
    }
}

