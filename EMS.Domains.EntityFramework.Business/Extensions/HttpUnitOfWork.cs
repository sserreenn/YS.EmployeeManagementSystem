using Microsoft.AspNetCore.Http;

namespace EMS.Domains.EntityFramework.Business.Extensions
;

public class HttpUnitOfWork : UnitOfWork
{
    public HttpUnitOfWork(EMSContext context, IHttpContextAccessor httpAccessor) : base(context)
    {
        //context.CurrentUserId = 0;
    }
}