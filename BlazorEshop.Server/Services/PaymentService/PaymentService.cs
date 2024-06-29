using BlazorEshop.Shared.DTO;
using Stripe;
using Stripe.Checkout;

namespace BlazorEshop.Server.Services.PaymentService
{
    public class PaymentService : IPaymentService
    {
        private readonly ICartService _cartService;
        private readonly IAuthService _authService;
        private readonly IOrderService _orderService;

        const string secret = "whsec_f1014ca3bd888d836509993eb6f073f33498c8e2f087649a9fff51dac04c1160";

        public PaymentService(ICartService cartService, IAuthService authService, IOrderService orderService)
        {
            StripeConfiguration.ApiKey = "sk_test_51PVHTrRrBy9khtxd8YcATCQ97bvodZuJZ5pRlCY4BEXgE3yDaP0nAk889vVvcnLL2l4id265YmtdACKki3GGM6Ma00PuqkKTHN";
            _cartService = cartService;
            _authService = authService;
            _orderService = orderService;
        }
        public async Task<Session> CreateCheckoutSession()
        {
            var products = (await _cartService.GetDbCartProducts()).Data;
            var lineItems = new List<SessionLineItemOptions>();
            products.ForEach(product => lineItems.Add(new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmountDecimal = product.Price * 100,
                    Currency = "usd",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = product.Title,
                        Images = new List<string> { product.ImageUrl }
                    }
                },
                Quantity = product.Quantity
            }));

            var options = new SessionCreateOptions()
            {
                CustomerEmail = _authService.GetUserEmail(),
                ShippingAddressCollection = 
                    new SessionShippingAddressCollectionOptions
                    {
                        AllowedCountries = new List<string> { "GR" }
                    },
                PaymentMethodTypes = new List<string>
                {
                    "card"
                },
                LineItems = lineItems,
                Mode = "payment",
                SuccessUrl = "https://localhost:7115/order-success",
                CancelUrl = "https://localhost:7115/cart"
            };

            var service = new SessionService();
            Session session = service.Create(options);
            return session;
        }

        public async Task<ServiceResponseDTO<bool>> FulfillOrder(HttpRequest request)
        {
            var json = await new StreamReader(request.Body).ReadToEndAsync();
            try
            {
                var stripeEvent = EventUtility.ConstructEvent(
                        json,
                        request.Headers["Stripe-Signature"],
                        secret
                    );

                if (stripeEvent.Type == Events.CheckoutSessionCompleted)
                {
                    var session = stripeEvent.Data.Object as Session;
                    var user = await _authService.GetUserByEmail(session.CustomerEmail);
                    await _orderService.PlaceOrder(user.Id);
                }

                return new ServiceResponseDTO<bool> { Data = true };
            }
            catch (StripeException e)
            {
                return new ServiceResponseDTO<bool> { Data = false, Success = false, Message = e.Message };
            }
        }
    }
}
