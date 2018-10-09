using System;

namespace BionicInventory.Application.ProductionOrders.Models
{
    public class ActiveOrdersView
    {
        public uint id {get; set;}
        public uint orderId {get; set;}
        public uint total {get; set;}
        public int remaining {get; set;}
        public DateTime dueDate {get; set;}
        public DateTime Start {get; set;}
    }
}