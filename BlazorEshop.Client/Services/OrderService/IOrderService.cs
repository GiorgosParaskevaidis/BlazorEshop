﻿using BlazorEshop.Shared.DTO;

namespace BlazorEshop.Client.Services.OrderService
{
    public interface IOrderService
    {
        Task<string> PlaceOrder();
        Task<List<OrderOverviewResponseDTO>> GetOrders();
        Task<OrderDetailsResponseDTO> GetOrderDetails(int orderId);
    }
}
