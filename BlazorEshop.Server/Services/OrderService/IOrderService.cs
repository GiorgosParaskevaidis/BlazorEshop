using BlazorEshop.Shared.DTO;

namespace BlazorEshop.Server.Services.OrderService
{
    public interface IOrderService
    {
        Task<ServiceResponseDTO<bool>> PlaceOrder(int userId);
        Task<ServiceResponseDTO<List<OrderOverviewResponseDTO>>> GetOrders();
        Task<ServiceResponseDTO<OrderDetailsResponseDTO>> GetOrderDetails(int orderId);
    }
}
