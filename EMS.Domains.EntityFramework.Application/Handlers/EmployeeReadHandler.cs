using AutoMapper;
using EMS.Core.Responses;
using EMS.Domains.EntityFramework.Application.Queries;
using EMS.Domains.EntityFramework.Entity.Repositories.Base;
using MediatR;

namespace EMS.Domains.EntityFramework.Application.Handlers
;

public class EmployeeReadHandler : IRequestHandler<GetEmployeeQuery, EmployeeResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EmployeeReadHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<EmployeeResponse> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.Employees.GetByIdAsync(request.predicate, request.includes);
        var response = _mapper.Map<EmployeeResponse>(entity);
        return response;
    }
}