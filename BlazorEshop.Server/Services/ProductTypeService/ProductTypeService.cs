
using BlazorEshop.Shared.DTO;

namespace BlazorEshop.Server.Services.ProductTypeService
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly BlazoreshopDbContex _context;

        public ProductTypeService(BlazoreshopDbContex context)
        {
            _context = context;
        }
        public async Task<ServiceResponseDTO<List<ProductType>>> AddProductType(ProductType productType)
        {
            productType.Editing = productType.IsNew = false;
            _context.ProductTypes.Add(productType);
            await _context.SaveChangesAsync();

            return await GetProductTypes();
        }

        public async Task<ServiceResponseDTO<List<ProductType>>> GetProductTypes()
        {
            var productTypes = await _context.ProductTypes.ToListAsync();
            return new ServiceResponseDTO<List<ProductType>> { Data =  productTypes };
            
        }

        public async Task<ServiceResponseDTO<List<ProductType>>> UpdateProductType(ProductType productType)
        {
            var dbProductType = await _context.ProductTypes.FindAsync(productType.Id);
            if (dbProductType == null)
            {
                return new ServiceResponseDTO<List<ProductType>>
                {
                    Success = false,
                    Message = "Product Type not found."
                };
            }

            dbProductType.Name = productType.Name;
            await _context.SaveChangesAsync();

            return await GetProductTypes();
        }
    }
}
