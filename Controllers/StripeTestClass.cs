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
    
        public class Program
        {
            public static void Main(string[] args)
            {
                WebHost.CreateDefaultBuilder(args)
                  .UseUrls("http://0.0.0.0:4242")
                  .UseWebRoot("public")
                  .UseStartup<Startup>()
                  .Build()
                  .Run();
            }
        }

        public class Startup
        {
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddMvc().AddNewtonsoftJson();
            }

            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {

                // This is your test secret API key.
                StripeConfiguration.ApiKey = "sk_test_51ShRUR1SjyxQIlE1tQMeTnJlQ4TwoksiRXtxnm4E0KnsYpWgV6oh6fXobmddyEtPhj0gWHEX5GYsYuuTMaDDtYQZ00hdRhAiWj";
                if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
                app.UseRouting();
                app.UseStaticFiles();
                app.UseEndpoints(endpoints => endpoints.MapControllers());
            }
        }

        [Route("create-payment-intent")]
        [ApiController]
        public class PaymentIntentApiController : Controller
        {
            [HttpPost]
            public ActionResult Create(PaymentIntentCreateRequest request)
            {
                var paymentIntentService = new PaymentIntentService();
                var paymentIntent = paymentIntentService.Create(new PaymentIntentCreateOptions
                {
                    Amount = CalculateOrderAmount(request.Items),
                    Currency = "aud",
                    // In the latest version of the API, specifying the `automatic_payment_methods` parameter is optional because Stripe enables its functionality by default.
                    AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions
                    {
                        Enabled = true,
                    },
                });

                return Json(new { clientSecret = paymentIntent.ClientSecret });
            }

            private long CalculateOrderAmount(Item[] items)
            {
                // Calculate the order total on the server to prevent
                // people from directly manipulating the amount on the client
                long total = 0;
                foreach (Item item in items)
                {
                    total += item.Amount;
                }
                return total;
            }

            public class Item
            {
                [JsonProperty("id")]
                public string Id { get; set; }
                [JsonProperty("Amount")]
                public long Amount { get; set; }
            }

            public class PaymentIntentCreateRequest
            {
                [JsonProperty("items")]
                public Item[] Items { get; set; }
            }
        }
    }

