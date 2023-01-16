using EMS.Core.Responses;
using MediatR;

namespace EMS.Domains.EntityFramework.Application.Commands.Checkins
{
    public class CheckinUpdateRequest : IRequest<BranchResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public int CompanyId { get; set; }
    }
}