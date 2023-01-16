using EMS.Core.Responses;
using MediatR;

namespace EMS.Domains.EntityFramework.Application.Commands.Companies
{
    public class CompanyDeleteRequest : IRequest<CompanyResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int BranchCount { get; set; }
        public int EmployeesCount { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
    }
}