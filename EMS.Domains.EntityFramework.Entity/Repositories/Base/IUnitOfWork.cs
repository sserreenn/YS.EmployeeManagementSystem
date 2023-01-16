using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Domains.EntityFramework.Entity.Repositories.Base
{
    public interface IUnitOfWork
    {

        ICompanyRepository Companies { get; }
        IBranchRepository Branchs { get; }
        IEmployeeRepository Employees { get; }
        ICheckinRepository Checkins { get; }


        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
