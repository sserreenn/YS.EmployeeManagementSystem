using EMS.Core.Responses;
using EMS.Domains.EntityFramework.Entity.Models;
using MediatR;
using System.Linq.Expressions;

namespace EMS.Domains.EntityFramework.Application.Queries;
public class GetCompanyQuery : IRequest<CompanyResponse>
{
    public Expression<Func<Company, bool>> predicate { get; set; }
    public IList<string> includes { get; set; }

    public GetCompanyQuery(Expression<Func<Company, bool>>? query, IList<string>? include)
    {
        if (query != null) predicate = query;
        if (include != null) includes = include;
    }
}