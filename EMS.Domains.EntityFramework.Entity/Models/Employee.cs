using EMS.Domains.EntityFramework.Entity.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS.Domains.EntityFramework.Entity.Models
{
    public class Employee : BaseEntity
    {
        public Employee()
        {
            this.Checkins = new HashSet<Checkin>();
        }
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public virtual Branch Branch { get; set; }

        public virtual ICollection<Checkin> Checkins { get; set; }
    }
}