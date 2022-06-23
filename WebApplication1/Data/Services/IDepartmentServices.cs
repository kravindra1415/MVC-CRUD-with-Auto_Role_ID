using WebApplication1.Data.ViewModel;

namespace WebApplication1.Data.Services
{
    public interface IDepartmentServices
    {
        Task CreateAsync(DepartmentViewModel departmentViewModel);
        Task DeleteAsync(int id);
        Task<List<DepartmentViewModel>> GetAllAsync();
        Task<DepartmentViewModel> GetByIdAsync(int id);
        Task UpdateAsync(DepartmentViewModel departmentViewModel);
    }
}