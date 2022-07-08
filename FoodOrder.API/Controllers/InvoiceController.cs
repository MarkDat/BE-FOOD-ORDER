using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FoodOrder.Application.Services.Interfaces;
using FoodOrder.Entity.Entities.Invoice;

namespace FoodOrder.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly ILogger<InvoiceController> _logger;
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(ILogger<InvoiceController> logger, IInvoiceService invoiceService)
        {
            _logger = logger;
            _invoiceService = invoiceService;
        }

        [HttpPost("{orderId:int}")]
        public async Task SignInvoice(int orderId)
        {
            _logger.LogInformation("Sign invoice with order id {Id}", orderId);
            await _invoiceService.Sign(orderId);
        }

        [HttpGet("{orderId:int}")]
        public async Task<string> ExportInvoice(int orderId)
        {
            _logger.LogInformation("Export invoice with order id {Id}", orderId);
            return await _invoiceService.Export(orderId);
        }
    }
}