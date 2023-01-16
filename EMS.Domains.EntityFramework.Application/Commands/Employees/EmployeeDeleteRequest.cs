using EMS.Core.Responses;
using MediatR;

namespace EMS.Domains.EntityFramework.Application.Commands.Employees
{
    public class EmployeeDeleteRequest : IRequest<EmployeeResponse>
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public int BranchId { get; set; }
    }
}