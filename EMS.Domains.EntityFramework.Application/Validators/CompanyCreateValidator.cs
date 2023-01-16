using EMS.Domains.EntityFramework.Application.Commands.Companies;
using FluentValidation;

namespace EMS.Domains.EntityFramework.Application.Validators
{
    public class CompanyCreateValidator : AbstractValidator<CompanyCreateRequest>
    {
        public CompanyCreateValidator()
        {
            RuleFor(v => v.Name)
                .NotEmpty()
                .WithMessage("İsim boş olamaz");
            RuleFor(v => v.Description)
                .NotEmpty()
                .WithMessage("Lütfen açıklama ekleyiniz.");
            RuleFor(v => v.Address)
                .NotEmpty()
                .WithMessage("Lütfen Adres ekleyiniz.");
            RuleFor(v => v.Phone)
                .NotEmpty()
                .WithMessage("Lütfen telefon numarası ekleyiniz.");
            RuleFor(v => v.Email)
                .NotEmpty()
                .WithMessage("Lütfen e-posta adresinizi ekleyiniz.");
        }
    }
}