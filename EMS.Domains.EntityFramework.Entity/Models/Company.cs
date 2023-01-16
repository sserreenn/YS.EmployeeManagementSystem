using EMS.Domains.EntityFramework.Entity.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace EMS.Domains.EntityFramework.Entity.Models
{
    public class Company : BaseEntity
    {
        public Company()
        {
            Branches = new HashSet<Branch>();
        }
        [Key]

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int BranchCount { get; set; }
        public int EmployeesCount { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }

        public virtual ICollection<Branch> Branches { get; set; }
    }
}