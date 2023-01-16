using EMS.Domains.EntityFramework.Application.Commands.Employees;
using FluentValidation;

namespace EMS.Domains.EntityFramework.Application.Validators
{
    public class EmployeeCreateValidator : AbstractValidator<EmployeeCreateRequest>
    {
        public EmployeeCreateValidator()
        {
            RuleFor(v => v.FirstName)
                .NotEmpty()
                .WithMessage("İsim boş olamaz");
            RuleFor(v => v.LastName)
                .NotEmpty()
                .WithMessage("Soyisim boş olamaz");
            RuleFor(v => v.Mail)
                .NotEmpty()
                .WithMessage("Lütfen e-posta adresinizi ekleyiniz.");
            RuleFor(v => v.Address)
                .NotEmpty()
                .WithMessage("Lütfen Adresinizi ekleyiniz.");
            RuleFor(v => v.Phone)
                .NotEmpty()
                .WithMessage("Lütfen telefon numarası ekleyiniz.");
        }
    }
}