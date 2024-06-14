
namespace BlazorEshop.Server.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly BlazoreshopDbContex _context;

        public CategoryService(BlazoreshopDbContex context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<Category>>> GetCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            return new ServiceResponse<List<Category>>
            {
                Data = categories
            };
        }
    }
}
