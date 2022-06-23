using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Data.Services;
using WebApplication1.Data.ViewModel;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeesService;

        public EmployeeController(IEmployeeService employeesService)
        {
            _employeesService = employeesService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var employees = await _employeesService.GetAllAsync();
            return View(employees);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var employee = await _employeesService.GetByIdAsync((int)id);

            if (employee == null)
                return NotFound();

            return View(employee);
        }

        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> Create()
        {
            ViewData["DepartmentList"] = await GetSelectListDepartmentAsync();
            ViewData["NationalityList"] = await GetSelectListNationalityAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> Create(EmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                await _employeesService.CreateAsync(employee);
                return RedirectToAction(nameof(Index));
            }

            ViewData["DepartmentList"] = await GetSelectListDepartmentAsync();
            ViewData["NationalityList"] = await GetSelectListNationalityAsync();

            return View(employee);
        }

        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> Edit(int id)
        {
            ViewData["DepartmentList"] = await GetSelectListDepartmentAsync();
            ViewData["NationalityList"] = await GetSelectListNationalityAsync();

            var userViewModel = await _employeesService.GetByIdAsync(id);
            return View(userViewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> Edit(EmployeeViewModel employee)
        {
            if (!ModelState.IsValid)
                return View(employee);

            await _employeesService.UpdateAsync(employee);

            ViewData["DepartmentList"] = await GetSelectListDepartmentAsync();
            ViewData["NationalityList"] = await GetSelectListNationalityAsync();

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Delete(int id)
        {
            var userViewModel = await _employeesService.GetByIdAsync(id);
            return View(userViewModel);
        }

        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _employeesService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<SelectList> GetSelectListDepartmentAsync()
        {
            return new SelectList(
                await _employeesService.GetDepartmentForDropDownAsync(),
                nameof(DropdownViewModel.Id), nameof(DropdownViewModel.Text));
        }

        private async Task<SelectList> GetSelectListNationalityAsync()
        {
            return new SelectList(
                await _employeesService.GetNationalityForDropDownAsync(),
                nameof(DropdownViewModel.Id), nameof(DropdownViewModel.Text));
        }
    }
}
