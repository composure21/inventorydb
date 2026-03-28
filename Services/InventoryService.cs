using InventorySystem.Models;

namespace InventorySystem.Services
{
    public class InventoryService
    {
        private readonly AppDbContext _context;

        public InventoryService(AppDbContext context)
        {
            _context = context;
        }

        // Update stock + log movement
        public void UpdateStock(int productId, int quantityChange, string reason)
        {
            var product = _context.Products.Find(productId);
            if (product == null) throw new Exception("Product not found");

            product.Quantity += quantityChange;

            var movement = new StockMovement
            {
                ProductId = productId,
                QuantityChanged = quantityChange,
                Reason = reason
            };

            _context.StockMovements.Add(movement);
            _context.SaveChanges();
        }

        // Low stock alert
        public bool IsLowStock(int productId)
        {
            var product = _context.Products.Find(productId);
            return product.Quantity <= product.LowStockThreshold;
        }
    }
}
