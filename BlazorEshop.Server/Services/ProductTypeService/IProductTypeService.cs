using BlazorEshop.Shared.DTO;

namespace BlazorEshop.Server.Services.ProductTypeService
{
    public interface IProductTypeService
    {
        Task<ServiceResponseDTO<List<ProductType>>> GetProductTypes();
        Task<ServiceResponseDTO<List<ProductType>>> AddProductType(ProductType productType);
        Task<ServiceResponseDTO<List<ProductType>>> UpdateProductType(ProductType productType);
    }
}
