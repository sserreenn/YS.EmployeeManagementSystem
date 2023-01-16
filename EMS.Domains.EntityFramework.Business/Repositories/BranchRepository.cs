using EMS.Domains.EntityFramework.Business.Repositories.Base;
using EMS.Domains.EntityFramework.Entity.Models;
using EMS.Domains.EntityFramework.Entity.Repositories;

namespace EMS.Domains.EntityFramework.Business.Repositories;

public class BranchRepository : Repository<Branch>, IBranchRepository
{
    public BranchRepository(EMSContext context) : base(context)
    { }
}