using BlazorEshop.Shared.DTO;

namespace BlazorEshop.Server.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<ServiceResponseDTO<List<Category>>> GetCategories();
        Task<ServiceResponseDTO<List<Category>>> GetAdminCategories();
        Task<ServiceResponseDTO<List<Category>>> AddCategory(Category category);
        Task<ServiceResponseDTO<List<Category>>> UpdateCategory(Category category);
        Task<ServiceResponseDTO<List<Category>>> DeleteCategory(int id);
    }
}
