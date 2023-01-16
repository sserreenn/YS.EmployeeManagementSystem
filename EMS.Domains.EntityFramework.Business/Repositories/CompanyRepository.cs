using EMS.Domains.EntityFramework.Business.Repositories.Base;
using EMS.Domains.EntityFramework.Entity.Models;
using EMS.Domains.EntityFramework.Entity.Repositories;

namespace EMS.Domains.EntityFramework.Business.Repositories;

public class CompanyRepository : Repository<Company>, ICompanyRepository
{
    public CompanyRepository(EMSContext context) : base(context)
    { }
}