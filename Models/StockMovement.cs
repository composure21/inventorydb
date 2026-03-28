namespace InventorySystem.Models
{
    public class StockMovement
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int QuantityChanged { get; set; } // +in, -out
        public DateTime Date { get; set; } = DateTime.UtcNow;

        public string Reason { get; set; }
    }
}
