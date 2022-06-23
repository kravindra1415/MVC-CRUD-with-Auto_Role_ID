using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.ViewModel
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Department")]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }
    }
}
