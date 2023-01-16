using EMS.Domains.EntityFramework.Entity.Enums;
using EMS.Domains.EntityFramework.Entity.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS.Domains.EntityFramework.Entity.Models
{
    public class Checkin : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public CheckinTypes Type { get; set; }
        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }
    }
}