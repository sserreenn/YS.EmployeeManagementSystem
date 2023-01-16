using AutoMapper;
using EMS.Core.Extensions;
using EMS.Core.Responses;
using EMS.Domains.EntityFramework.Application.Commands.Employees;
using EMS.Domains.EntityFramework.Entity.Models;
using EMS.Domains.EntityFramework.Entity.Repositories.Base;
using MediatR;

namespace EMS.Domains.EntityFramework.Application.Handlers
{
    public class EmployeeCreateHandler : IRequestHandler<EmployeeCreateRequest, EmployeeResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeCreateHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<EmployeeResponse> Handle(EmployeeCreateRequest request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Employees.GetByIdAsync(r => r.Mail == request.Mail || r.Phone == request.Phone);
            if (entity != null)
                throw new AppException(0, "Şube tanımlı, e-posta ya da telefon bilgilerini kontrol ederek yeniden ekleme yapabilirsiniz.");

            var newEntity = _mapper.Map<Employee>(request);
            //  entity = _mapper.Map(request, entity );

            await _unitOfWork.Employees.AddAsync(newEntity);

            return _mapper.Map<EmployeeResponse>(newEntity);
        }
    }
}