using System;
using System.Collections.Generic;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Stripe;

namespace MiMochiRentals.Controllers
{
    [Route("UpdateIntent")]
    [ApiController]
    public class UpdateIntentController() : Controller
    {
        [HttpPost("metadata")]
        public async Task<IActionResult> UpdatePaymentIntentMetadata([FromBody] UpdateMetadataRequest request)

        {
            Console.WriteLine("Updating payment metadata");
            var service = new PaymentIntentService();
            var options = new PaymentIntentUpdateOptions
            {
                Metadata = new Dictionary<string, string>
                {
                    { "internalOrderId", request.OrderId.ToString() }
                }
            };

            var updatedIntent = await service.UpdateAsync(request.PaymentIntentId, options);

            return Ok(new { success = true });
        }

        public class UpdateMetadataRequest
        {
            public string PaymentIntentId { get; set; }
            public int OrderId { get; set; }
        }
    }
}

