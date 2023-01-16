using AutoMapper;
using EMS.Core.Extensions;
using EMS.Core.Responses;
using EMS.Domains.EntityFramework.Application.Commands.Branchs;
using EMS.Domains.EntityFramework.Entity.Models;
using EMS.Domains.EntityFramework.Entity.Repositories.Base;
using MediatR;

namespace EMS.Domains.EntityFramework.Application.Handlers
{
    public class BranchCreateHandler : IRequestHandler<BranchCreateRequest, BranchResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BranchCreateHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BranchResponse> Handle(BranchCreateRequest request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Branchs.GetByIdAsync(r => r.Name == request.Name || r.Code == request.Code);
            if (entity != null)
                throw new AppException(0, "Şube tanımlı, şube ismi ya da kodunu kontrol ederek yeniden ekleme yapabilirsiniz.");

            var newEntity = _mapper.Map<Branch>(request);
            //  entity = _mapper.Map(request, entity );

            await _unitOfWork.Branchs.AddAsync(newEntity);

            return _mapper.Map<BranchResponse>(newEntity);
        }
    }
}