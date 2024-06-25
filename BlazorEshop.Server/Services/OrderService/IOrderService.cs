﻿using BlazorEshop.Shared.DTO;

namespace BlazorEshop.Server.Services.OrderService
{
    public interface IOrderService
    {
        Task<ServiceResponse<bool>> PlaceOrder(int userId);
        Task<ServiceResponse<List<OrderOverviewResponseDTO>>> GetOrders();
        Task<ServiceResponse<OrderDetailsResponseDTO>> GetOrderDetails(int orderId);
    }
}
