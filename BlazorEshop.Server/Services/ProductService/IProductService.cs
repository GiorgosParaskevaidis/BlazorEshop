using BlazorEshop.Shared.DTO;

namespace BlazorEshop.Server.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponseDTO<List<Product>>> GetProductsAsync();
        Task<ServiceResponseDTO<Product>> GetProductAsync(int productId);

        Task<ServiceResponseDTO<List<Product>>> GetProductsByCategory(string categoryUrl);

        Task<ServiceResponseDTO<ProductSearchResultDTO>> SearchProducts(string searchText, int page);

        Task<ServiceResponseDTO<List<string>>> GetProductSearchSuggestions(string searchText);
        Task<ServiceResponseDTO<List<Product>>> GetFeaturedProducts();
        Task<ServiceResponseDTO<List<Product>>> GetAdminProducts();
        Task<ServiceResponseDTO<Product>> CreateProduct(Product product);
        Task<ServiceResponseDTO<Product>> UpdateProduct(Product product);
        Task<ServiceResponseDTO<bool>> DeleteProduct(int productId);
    }
}
