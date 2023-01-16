using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Domains.EntityFramework.Entity.Models.Base
{
    public interface IBaseEntity
    {
        int CreatedBy { get; set; }
        int UpdatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime? UpdatedDate { get; set; }
        bool Status { get; set; }
        bool IsDeleted { get; set; }
    }

    public class BaseEntity : IBaseEntity
    {
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }

        public BaseEntity Clone()
        {
            return (BaseEntity)this.MemberwiseClone();
        }
    }
}
