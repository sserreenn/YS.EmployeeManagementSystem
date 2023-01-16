using EMS.Domains.EntityFramework.Business.Repositories.Base;
using EMS.Domains.EntityFramework.Entity.Models;
using EMS.Domains.EntityFramework.Entity.Repositories;

namespace EMS.Domains.EntityFramework.Business.Repositories;

public class CheckinRepository : Repository<Checkin>, ICheckinRepository
{
    public CheckinRepository(EMSContext context) : base(context)
    { }
}