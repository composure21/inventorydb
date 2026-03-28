using System.ComponentModel.DataAnnotations.Schema;

namespace InventorySystem.Models {
    public class Product {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Quantity { get; set; }
        public int LowStockThreshold { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public ICollection<StockMovement> Movements { get; set; }
    }
}

