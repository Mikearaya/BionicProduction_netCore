namespace BionicInventory.Application.Invoices.Models.ViewModels {
    public class InvoiceItems {
        public uint id { get; set; }
        public uint itemId { get; set; }
        public uint customerOrderItemId { get; set; }

        public string ItemName { get; set; }
        public float? unitPrice { get; set; }

        public float? quantity { get; set; }

        public float? discount { get; set; }

    }
}