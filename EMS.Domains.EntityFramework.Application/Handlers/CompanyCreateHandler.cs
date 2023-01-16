using AutoMapper;
using EMS.Core.Extensions;
using EMS.Core.Responses;
using EMS.Domains.EntityFramework.Application.Commands.Companies;
using EMS.Domains.EntityFramework.Entity.Models;
using EMS.Domains.EntityFramework.Entity.Repositories.Base;
using MediatR;

namespace EMS.Domains.EntityFramework.Application.Handlers
{
    public class CompanyCreateHandler : IRequestHandler<CompanyCreateRequest, CompanyResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CompanyCreateHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CompanyResponse> Handle(CompanyCreateRequest request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Companies.GetByIdAsync(r => r.Name == request.Name);
            if (entity != null)
                throw new AppException(0, "Firma tanımlı");

            var newEntity = _mapper.Map<Company>(request);
            //  entity = _mapper.Map(request, entity );

            await _unitOfWork.Companies.AddAsync(newEntity);

            return _mapper.Map<CompanyResponse>(newEntity);
        }
    }
}