using InventorySystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Controllers
{
    [ApiController]
    [Route("api/stock")]
    public class StockController : ControllerBase
    {
        private readonly InventoryService _service;

        public StockController(InventoryService service)
        {
            _service = service;
        }

        [HttpPost("update")]
        public IActionResult UpdateStock(int productId, int quantity, string reason)
        {
            _service.UpdateStock(productId, quantity, reason);
            return Ok("Stock updated");
        }

        [HttpGet("low/{productId}")]
        public IActionResult CheckLowStock(int productId)
        {
            var isLow = _service.IsLowStock(productId);
            return Ok(new { LowStock = isLow });
        }
    }
}
