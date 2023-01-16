using AutoMapper;
using EMS.Core.Responses;
using EMS.Domains.EntityFramework.Application.Queries;
using EMS.Domains.EntityFramework.Entity.Repositories.Base;
using MediatR;

namespace EMS.Domains.EntityFramework.Application.Handlers
;

public class BranchReadHandler : IRequestHandler<GetBranchQuery, BranchResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BranchReadHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<BranchResponse> Handle(GetBranchQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.Branchs.GetByIdAsync(request.predicate, request.includes);
        var response = _mapper.Map<BranchResponse>(entity);
        return response;
    }
}