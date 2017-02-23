using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Xml.Linq;

namespace LinqSalesStudent
{
    public partial class Customer
    {
        /// <summary>
        /// TotalSales is the sum of the SalesOrders' OrderTotal
        /// </summary>
        public decimal TotalSales => (from  so in SalesOrders select so.OrderTotal).Sum();
        /// <summary>
        /// TotalCost is the sum of the SalesOrders' OrderCost
        /// </summary>
        public decimal TotalCost => (from oc in SalesOrders select oc.OrderCost).Sum();
        /// <summary>
        /// GrossProfit is the difference between TotalSales and TotalCost
        /// </summary>
        public decimal GrossProfit => (  TotalSales - TotalCost);

        /// <summary>
        /// ItemsSold is the sum of the SalesOrders' SalesOrderParts Quantities
        /// </summary>
        public int ItemsSold => 0;// (from qs in SalesOrders select qs.SalesOrderParts).Sum(); //;

        /// <summary>
        /// LargestSale is the largest sale for the Customer based on OrderTotal
        /// </summary>
        public SalesOrder LargestSale => new SalesOrder();
        /// <summary>
        /// Returns a collection (List) of the items that a Customer has purchased, with the total quantities
        /// Group the SalesOrderParts from the SalesOrders. Group by the Part's PartId and Name
        /// For each group, 
        ///     create a new CustomerItem object summing the 
        ///     Quantites, ExtendedPrices, UnitsShipped and 
        ///     the differences between Quantities and UnitsShipped for the Backorder
        /// </summary>
        public List<CustomerItem> CustomerItems
        {
            get { return new List<CustomerItem>(); }
        }
    }
    public partial class Part
    {
        public const string StudentName = "Chris Jernigan";
        #region Quantities
        /// <summary>
        /// QuantityOnHand = Units Received - Units Spoiled - Units Shipped
        /// </summary>
        public int QuantityOnHand => 0;

        /// <summary>
        /// UnitsReceived is the sum of the Receipt Quantities for the Part
        /// </summary>
        public int UnitsReceived => (from rq in Receipts select  rq.Quantity).Sum();

        /// <summary>
        /// UnitsSold is the sum of the sales for the Part. Use SalesOrderParts.
        /// </summary>
        public int UnitsSold => 0;//(from pt in SalesOrderParts select  pt.Part).Sum(us =>us.Price);

        /// <summary>
        /// UnitsShipped is the sum of the quantities shipped for the Part. Use ShipmentParts.
        /// </summary>
        public int UnitsShipped => 0;

        /// <summary>
        /// UnitsSpoiled is the sum of the quantities for the Part. Use Spoilages.
        /// </summary>
        public int UnitsSpoiled => (from ps in Spoilages select  ps.SpoilageId).Sum();
        #endregion
        #region Amounts

        /// <summary>
        /// CurrentValue = Amount Received - Amount Spoiled - Amount Shipped
        /// </summary>
        public decimal CurrentValue => 0; //AmountReceived - AmountShipped - AmountSpoiled;
        /// <summary>
        /// Amount Sold is the sum of the extended prices for the SalesOrderParts.
        /// </summary>
        public decimal AmountSold => 0;
        /// <summary>
        /// AmountReceived is the sum of the Receipts' total cost + shipping and handling.
        /// </summary>
        public decimal AmountReceived => 0;
        /// <summary>
        /// AmountShipped is the sum of the Extended Costs for the Shipment Parts.
        /// </summary>
        public decimal AmountShipped => 0;

        /// <summary>
        /// AmountSpoiled is the sum of the Extended Costs for the Spoilages.
        /// </summary>
        public decimal AmountSpoiled => 0;
        #endregion
        /// <summary>
        /// Vendors is the list of Vendors that we have purchased this part from.
        /// Start with Purchase Order Parts, find the Purchase Order for each one
        /// Then get the Vendors for the Purchase Orders.
        /// We only want one distinct object for each vendor.
        /// Create a List of the Vendors.
        /// </summary>
        public List<Vendor> Vendors => new List<Vendor>();
    }
    public partial class SalesOrder
    {
        #region Quantities

        /// <summary>
        /// ItemsSold is the sum of the quantities for SalesOrderParts
        /// </summary>
        public int ItemsSold => (from qs in SalesOrderParts select  qs.Quantity).Sum(); 
       

        /// <summary>
        /// ItemsShipped is the sum of the Shipments' ShipmentParts' Quantities
        /// </summary>
        public int ItemsShipped => 0;  //DOES NOT WORK (from ms in Shipments select  ms.ShipmentParts).Sum(ex =>ex);//   
        /// <summary>
        /// BackOrdered is the difference between the Items Sold and the Items Shipped
        /// </summary>
        public int BackOrdered => 0;
        #endregion
        #region Amounts
        /// <summary>
        /// OrderTotal is the sum of the SalesOrderParts' Extended Prices
        /// </summary>
        public decimal OrderTotal => (from ep in SalesOrderParts select ep.ExtendedPrice).Sum();
        /// <summary>
        /// OrderCost is the sum of the SalesOrderPart's Extended Costs
        /// </summary>
        public decimal OrderCost => SalesOrderParts.Sum(sop => sop.ExtendedCost);
        /// <summary>
        /// GrossProfit is the difference between the Order Total and the Order Cost
        /// </summary>
        public decimal GrossProfit => OrderTotal - OrderCost;
        #endregion
    }
    public partial class SalesOrderPart
    {
        /// <summary>
        /// ExtendedPrice is the Quantity * the Unit Price
        /// </summary>
        public decimal ExtendedPrice => Quantity*UnitPrice;
        /// <summary>
        /// ExtendedCost is the Quantity * the Unit Cost
        /// </summary>
        public decimal ExtendedCost => Quantity*UnitCost;
        /// <summary>
        /// GrossProfit is the difference between the extended price and the extended cost
        /// </summary>
        public decimal GrossProfit =>  ExtendedPrice- ExtendedCost;
        /// <summary>
        /// UnitsShipped is the sum of the quantities of the Shipment Parts
        /// </summary>
        public int UnitsShipped => (from un in ShipmentParts select un.Quantity).Sum();
    }

    public partial class PurchaseOrder
    {
        /// <summary>
        /// OrderTotal is the sum of the Extended Costs for the Purchase Order Parts
        /// </summary>
        public decimal OrderTotal => (from pop in PurchaseOrderParts select pop).Sum(pop => pop.ExtendedCost);
//        {
//     get { return PurchaseOrderParts
//    }
//}
}
    public partial class PurchaseOrderPart
    {
        /// <summary>
        /// ExtendedCost is the Quantity * the Unit Cost
        /// </summary>
        public decimal ExtendedCost => Quantity*UnitCost;
    }
    public partial class Receipt
    {
        /// <summary>
        /// UnitCost is the (total cost + shipping and handling) / Quantity
        /// If the Quantity is 0, the Unit Cost is 0
        /// (Remember the C# ternary operator?)
        /// </summary>
        public decimal UnitCost => Quantity == 0 ? 0m : (TotalCost + ShippingAndHandling)/Quantity;
    }
    public partial class Spoilage
    {
        /// <summary>
        /// ExtendedCost is the Quantity * the Unit Cost
        /// </summary>
        public decimal ExtendedCost => Quantity*UnitCost;
    }
    public partial class Shipment
    {
        /// <summary>
        /// SalesOrderNumber is the SalesOrder's Sales Order Number
        /// </summary>
        public int SalesOrderNumber => SalesOrder.SalesOrderNumber;
        /// <summary>
        /// ShipmentAmount is the sum of the Extended Costs for the Shipment Parts
        /// </summary>
        public decimal ShipmentAmount => (from so in ShipmentParts select so).Sum(eo => eo.ExtendedCost);
    }
    public partial class ShipmentPart
    {
        /// <summary>
        /// ShipmentId is the Shipment's ShipmentId
        /// </summary>
        public int ShipmentId => Shipment.ShipmentId;
        /// <summary>
        /// ExtendedCost is the Quantity * the Unit Cost
        /// </summary>
        public decimal ExtendedCost => Quantity*UnitCost;
    }
    public partial class Vendor
    {
        /// <summary>
        /// TotalPurchases is the sum of the Purchase Orders order total
        /// </summary>
        /// 
        public int ItemsSold => 0;//(from  tp in PurchaseOrders select tp.PurchaseOrderParts).Sum();
        public decimal TotalPurchases => (from po in PurchaseOrders select po.OrderTotal).Sum();
    }
}