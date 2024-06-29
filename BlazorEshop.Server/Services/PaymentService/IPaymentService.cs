using BlazorEshop.Shared.DTO;
using Stripe.Checkout;

namespace BlazorEshop.Server.Services.PaymentService
{
    public interface IPaymentService
    {
        Task<Session> CreateCheckoutSession();
        Task<ServiceResponseDTO<bool>> FulfillOrder(HttpRequest request);
    }
}
