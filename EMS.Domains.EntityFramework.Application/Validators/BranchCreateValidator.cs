using EMS.Domains.EntityFramework.Application.Commands.Branchs;
using FluentValidation;

namespace EMS.Domains.EntityFramework.Application.Validators
{
    public class BranchCreateValidator : AbstractValidator<BranchCreateRequest>
    {
        public BranchCreateValidator()
        {
            RuleFor(v => v.Name)
                .NotEmpty()
                .WithMessage("İsim boş olamaz");
            RuleFor(v => v.Code)
                .NotEmpty()
                .WithMessage("Lütfen şube kodunu ekleyiniz.");
            RuleFor(v => v.Address)
                .NotEmpty()
                .WithMessage("Lütfen Adres ekleyiniz.");
            RuleFor(v => v.Phone)
                .NotEmpty()
                .WithMessage("Lütfen telefon numarası ekleyiniz.");
        }
    }
}