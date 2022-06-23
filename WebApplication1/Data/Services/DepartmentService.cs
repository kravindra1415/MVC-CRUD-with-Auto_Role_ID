using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Models;
using WebApplication1.Data.ViewModel;

namespace WebApplication1.Data.Services
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public DepartmentServices(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<DepartmentViewModel>> GetAllAsync()
        {
            var departments = await _dbContext.Departments
                .Select(d => _mapper.Map<DepartmentViewModel>(d)).ToListAsync();

            return departments;

        }

        public async Task<DepartmentViewModel> GetByIdAsync(int id)
        {
            var department = await _dbContext.Departments.FirstOrDefaultAsync(m => m.Id == id);
            return _mapper.Map<DepartmentViewModel>(department);
        }

        public async Task CreateAsync(DepartmentViewModel departmentViewModel)
        {
            var departmentDataModel = _mapper.Map<Department>(departmentViewModel);

            _dbContext.Add(departmentDataModel);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(DepartmentViewModel departmentViewModel)
        {
            var departmentToUpdate = await _dbContext.Departments.SingleAsync(d => d.Id == departmentViewModel.Id);

            departmentToUpdate.Name = departmentViewModel.Name;
            departmentToUpdate.Description = departmentViewModel.Description;

            _dbContext.Departments.Update(departmentToUpdate);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var departmentToDelete = await _dbContext.Departments.SingleAsync(d => d.Id == id);

            _dbContext.Departments.Remove(departmentToDelete);
            await _dbContext.SaveChangesAsync();
        }

    }
}
