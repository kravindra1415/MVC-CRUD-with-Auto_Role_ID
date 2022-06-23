using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data.Models
{
    public class Department
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        //for not doing the Auto increnment id
        public int Id { get; set; }

        [Unicode(false)]//for change data type from nvarchar to varchar
        [StringLength(50)]
        public string Name { get; set; } = null!;

        [Unicode(false)]
        [StringLength(500)]
        public string? Description { get; set; }
    }
}
