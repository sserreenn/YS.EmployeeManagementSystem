using EMS.Core.Responses;
using EMS.Domains.EntityFramework.Entity.Models;
using MediatR;
using System.Linq.Expressions;

namespace EMS.Domains.EntityFramework.Application.Queries;
public class GetBranchQuery : IRequest<BranchResponse>
{
    public Expression<Func<Branch, bool>> predicate { get; set; }
    public IList<string> includes { get; set; }

    public GetBranchQuery(Expression<Func<Branch, bool>>? query, IList<string>? include)
    {
        if (query != null) predicate = query;
        if (include != null) includes = include;
    }
}