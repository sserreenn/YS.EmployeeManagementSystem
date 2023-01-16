using AutoMapper;
using EMS.Core.Responses;
using EMS.Domains.EntityFramework.Application.Queries;
using EMS.Domains.EntityFramework.Entity.Repositories.Base;
using MediatR;

namespace EMS.Domains.EntityFramework.Application.Handlers
;

public class CompanyReadHandler : IRequestHandler<GetCompanyQuery, CompanyResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CompanyReadHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<CompanyResponse> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.Companies.GetByIdAsync(request.predicate, request.includes);
        var response = _mapper.Map<CompanyResponse>(entity);
        return response;
    }
}