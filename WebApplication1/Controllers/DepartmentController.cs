using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Services;
using WebApplication1.Data.ViewModel;

namespace WebApplication1.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentServices _departmentsService;

        public DepartmentController(IDepartmentServices departmentsService)
        {
            _departmentsService = departmentsService;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var departments = await _departmentsService.GetAllAsync();
            return View(departments);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var department = await _departmentsService.GetByIdAsync((int)id);

            if (department == null)
                return NotFound();

            return View(department);
        }
        [Authorize(Roles = "Admin,SuperAdmin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> Create(DepartmentViewModel department)
        {
            if (ModelState.IsValid)
            {
                await _departmentsService.CreateAsync(department);
                return RedirectToAction(nameof(Index));
            }

            return View(department);
        }

        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> Edit(int id)
        {
            var departmentViewModel = await _departmentsService.GetByIdAsync(id);
            return View(departmentViewModel);
        }


        [HttpPost]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> Edit(DepartmentViewModel departmentViewModel)
        {
            if (!ModelState.IsValid)
                return View(departmentViewModel);

            await _departmentsService.UpdateAsync(departmentViewModel);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Delete(int id)
        {
            var departmentviewModel = await _departmentsService.GetByIdAsync(id);
            return View(departmentviewModel);
        }

        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            await _departmentsService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
