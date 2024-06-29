using BlazorEshop.Shared.DTO;

namespace BlazorEshop.Server.Services.CartService
{
    public interface ICartService
    {
        Task<ServiceResponseDTO<List<CartProductResponseDTO>>> GetCartProducts(List<CartItem> cartItems);
        Task<ServiceResponseDTO<List<CartProductResponseDTO>>> StoreCartItems(List<CartItem> cartItems);
        Task<ServiceResponseDTO<int>> GetCartItemsCount();
        Task<ServiceResponseDTO<List<CartProductResponseDTO>>> GetDbCartProducts(int? userId = null);
        Task<ServiceResponseDTO<bool>> AddToCart(CartItem cartItem);
        Task<ServiceResponseDTO<bool>> UpdateQuantity(CartItem cartItem);
        Task<ServiceResponseDTO<bool>> RemoveItemFromCart(int productId, int productTypeId);
    }
}
