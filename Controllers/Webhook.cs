using Microsoft.AspNetCore.Mvc;
using Stripe;
using System;

namespace MiMochiRentals.Controllers
{
        [Route("api/webhook")]
        [ApiController]
        public class StripeWebhookController : ControllerBase
        {
            private readonly string _webhookSecret;
            private readonly OrderService _orderService;
            private readonly ILogger<StripeWebhookController> _logger;

            public StripeWebhookController(IConfiguration config, OrderService orderService, ILogger<StripeWebhookController> logger)
            {
                // Grab the secret from appsettings.json
                _webhookSecret = "whsec_be22bf693a9d876dbfd085985d861807f4116a2a12aa3308077ab594f7f61861";
                _orderService = orderService;
                _logger = logger;
            }

            [HttpPost]
            [IgnoreAntiforgeryToken] // MUST have this to allow Stripe to bypass CSRF
            public async Task<IActionResult> Index()
            {
            Console.WriteLine("Hitting webhook");
                // 1. Read the raw request body
                var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

                try
                {
                    // 2. Verify the signature (The "ID Badge" check)
                    var stripeEvent = EventUtility.ConstructEvent(
                        json,
                        Request.Headers["Stripe-Signature"],
                        _webhookSecret
                    );

                    // 3. Handle the event type
                    switch (stripeEvent.Type)
                    {

                        case "payment_intent.succeeded":
                            var paymentIntent = stripeEvent.Data.Object as PaymentIntent;
                            var orderId = Int32.Parse(paymentIntent.Metadata["internalOrderId"]);

                            _logger.LogInformation($"SUCCESS: Payment received for Order {orderId}");
                            
                            // Use your Service to update DB to "Paid"
                            await _orderService.UpdateOrder(orderId, "Paid");
                            break;
                        case "charge.succeeded":
                            Console.WriteLine("Payment Suceeded");
                            break;

                        case "payment_intent.payment_failed":
                            var failedIntent = stripeEvent.Data.Object as PaymentIntent;
                            var failedOrderId = Int32.Parse(failedIntent.Metadata["InternalOrderId"]);

                            _logger.LogWarning($"FAILURE: Payment failed for Order {failedOrderId}");

                            // Use your Service to update DB to "Failed"
                            await _orderService.UpdateOrder(failedOrderId, "Payment Failed");
                            break;

                        default:
                            _logger.LogInformation($"Unhandled event type: {stripeEvent.Type}");
                            break;
                    }

                    // 4. Return 200 OK so Stripe stops retrying
                    return Ok();
                }
                catch (StripeException e)
                {
                    _logger.LogError($"Stripe Webhook Error: {e.Message}");
                    return BadRequest();
                }
            }
        }
    
}
