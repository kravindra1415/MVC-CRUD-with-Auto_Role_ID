using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Unicode(false)]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        public DateTime? DateOfBirth { get; set; }

        [Column(TypeName = "char(1)")]
        public char? Gender { get; set; }

        public int DepartmentRefId { get; set; }

        [ForeignKey(nameof(DepartmentRefId))]
        public Department DepartmentRef { get; set; } = null!;

        public int NationalityRefId { get; set; }

        [ForeignKey(nameof(NationalityRefId))]
        public Nationality NationalityRef { get; set; } = null!;
    }
}
