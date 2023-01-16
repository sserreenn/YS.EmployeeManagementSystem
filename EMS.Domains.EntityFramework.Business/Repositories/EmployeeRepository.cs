using EMS.Domains.EntityFramework.Business.Repositories.Base;
using EMS.Domains.EntityFramework.Entity.Models;
using EMS.Domains.EntityFramework.Entity.Repositories;

namespace EMS.Domains.EntityFramework.Business.Repositories;

public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(EMSContext context) : base(context)
    { }
}