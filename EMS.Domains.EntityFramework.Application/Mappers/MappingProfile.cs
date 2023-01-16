using AutoMapper;
using EMS.Core.Responses;
using EMS.Domains.EntityFramework.Application.Commands.Branchs;
using EMS.Domains.EntityFramework.Application.Commands.Checkins;
using EMS.Domains.EntityFramework.Application.Commands.Companies;
using EMS.Domains.EntityFramework.Application.Commands.Employees;
using EMS.Domains.EntityFramework.Entity.Models;

namespace EMS.Domains.EntityFramework.Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyResponse>().ReverseMap();
            CreateMap<Company, CompanyCreateRequest>().ReverseMap();
            CreateMap<Company, CompanyUpdateRequest>().ReverseMap();
            CreateMap<Branch, BranchResponse>().ReverseMap();
            CreateMap<Branch, BranchCreateRequest>().ReverseMap();
            CreateMap<Branch, BranchUpdateRequest>().ReverseMap();
            CreateMap<Employee, EmployeeResponse>().ReverseMap();
            CreateMap<Employee, EmployeeCreateRequest>().ReverseMap();
            CreateMap<Employee, EmployeeUpdateRequest>().ReverseMap();
            CreateMap<Checkin, CheckinResponse>().ReverseMap();
            CreateMap<Checkin, CheckinCreateRequest>().ReverseMap();
            CreateMap<Checkin, CheckinUpdateRequest>().ReverseMap();
        }
    }
}