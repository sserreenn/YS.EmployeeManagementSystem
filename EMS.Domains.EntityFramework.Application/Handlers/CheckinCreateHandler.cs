using AutoMapper;
using EMS.Core.Extensions;
using EMS.Core.Responses;
using EMS.Domains.EntityFramework.Application.Commands.Checkins;
using EMS.Domains.EntityFramework.Entity.Models;
using EMS.Domains.EntityFramework.Entity.Repositories.Base;
using MediatR;

namespace EMS.Domains.EntityFramework.Application.Handlers
{
    public class CheckinCreateHandler : IRequestHandler<CheckinCreateRequest, CheckinResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CheckinCreateHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CheckinResponse> Handle(CheckinCreateRequest request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Checkins.GetByIdAsync(r => r.EmployeeId == request.EmployeeId && r.Type == request.Type);
            if (entity != null)
                if (entity.Type == Entity.Enums.CheckinTypes.Login)
                    throw new AppException(0, "Giriş yapabilmek için önce çıkış yapmanız gerekmektedir.");
                else
                    throw new AppException(0, "Çıkış yapabilmek için önce giriş yapmanız gerekmektedir.");

            var newEntity = _mapper.Map<Checkin>(request);

            await _unitOfWork.Checkins.AddAsync(newEntity);

            return _mapper.Map<CheckinResponse>(newEntity);
        }
    }
}