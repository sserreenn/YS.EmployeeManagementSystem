using EMS.Domains.EntityFramework.Entity.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS.Domains.EntityFramework.Entity.Models
{
    public class Branch : BaseEntity
    {

        public Branch()
        {
            this.Employees = new HashSet<Employee>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}