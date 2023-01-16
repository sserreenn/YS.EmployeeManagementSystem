using EMS.Core.Responses;
using EMS.Domains.EntityFramework.Entity.Models;
using MediatR;
using System.Linq.Expressions;

namespace EMS.Domains.EntityFramework.Application.Queries;
public class GetCheckinQuery : IRequest<CheckinResponse>
{
    public Expression<Func<Checkin, bool>> predicate { get; set; }
    public IList<string> includes { get; set; }

    public GetCheckinQuery(Expression<Func<Checkin, bool>>? query, IList<string>? include)
    {
        if (query != null) predicate = query;
        if (include != null) includes = include;
    }
}