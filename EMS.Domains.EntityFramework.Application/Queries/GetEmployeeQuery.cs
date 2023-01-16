using EMS.Core.Responses;
using EMS.Domains.EntityFramework.Entity.Models;
using MediatR;
using System.Linq.Expressions;

namespace EMS.Domains.EntityFramework.Application.Queries;
public class GetEmployeeQuery : IRequest<EmployeeResponse>
{
    public Expression<Func<Employee, bool>> predicate { get; set; }
    public IList<string> includes { get; set; }

    public GetEmployeeQuery(Expression<Func<Employee, bool>>? query, IList<string>? include)
    {
        if (query != null) predicate = query;
        if (include != null) includes = include;
    }
}