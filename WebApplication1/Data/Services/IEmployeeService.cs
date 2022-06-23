using WebApplication1.Data.ViewModel;

namespace WebApplication1.Data.Services
{
    public interface IEmployeeService
    {
        Task CreateAsync(EmployeeViewModel employee);
        Task DeleteAsync(int id);
        Task<List<EmployeeViewModel>> GetAllAsync();
        Task<EmployeeViewModel?> GetByIdAsync(int id);
        Task<List<DropdownViewModel>> GetDepartmentForDropDownAsync();
        Task<List<DropdownViewModel>> GetNationalityForDropDownAsync();
        Task UpdateAsync(EmployeeViewModel employeeViewModel);
    }
}