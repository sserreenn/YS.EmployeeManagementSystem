using EMS.Core.Responses;
using EMS.Domains.EntityFramework.Entity.Enums;
using MediatR;

namespace EMS.Domains.EntityFramework.Application.Commands.Checkins
{
    public class CheckinCreateRequest : IRequest<CheckinResponse>
    {
        public DateTime Time { get; set; }
        public CheckinTypes Type { get; set; }
        public int EmployeeId { get; set; }
    }
}