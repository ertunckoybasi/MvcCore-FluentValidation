using FluentValidation;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace MvcCore_FluentValidation.Models
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Please specify a {PropertyName}")
                .Must(IsValidName).WithMessage("{PropertyName} should be all letters.");
            ///Used Custom Validator Function IsValidName ,  IsValidName fonksiyonu kullanıldı

            RuleFor(x => x.Address).NotEmpty().WithMessage("Please specift a {PropertyName}")
               .Length(10, 200).WithMessage("Address lenght must be between 10 - 200 ");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Please specify a {PropertyName}")
                .EmailAddress().WithMessage("{PropertyName} is not valid");

            RuleFor(x => x.Country).NotEmpty().WithMessage("Please specify a {PropertyName}");

            RuleFor(x => x.Age).NotNull().WithMessage("Please specify a {PropertyName}")
                .InclusiveBetween(18, 65).WithMessage("{PropertyName} must be between 18-65");

            RuleFor(x => x.Salary).NotNull().WithMessage("Please specify a {PropertyName}");

            RuleFor(p => p.Phone)
                   .NotEmpty()
                   .NotNull().WithMessage("Phone Number is required.")
                   .MinimumLength(10).WithMessage("{PropertyName} must not be less than 10 characters.")
                   .MaximumLength(20).WithMessage("{PropertyName} must not exceed 50 characters.")
                   .Matches(new Regex(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}")).WithMessage("PhoneNumber not valid");

        }

        private bool IsValidName(string name)
        {
            if (name == null) return false;
            return name.All(Char.IsLetter);
        }
    }
}
