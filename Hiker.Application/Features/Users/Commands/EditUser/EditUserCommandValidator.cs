using System;
using System.Text.RegularExpressions;
using FluentValidation;
using Hiker.Application.Features.Trips.Commands.AddTrip;

namespace Hiker.Application.Features.Users.Commands.EditUser
{
    public class EditUserCommandValidator : AbstractValidator<EditUserCommand>
    {
        public EditUserCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.LastName)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Birthday)
                .Must(x => x > DateTime.Now.AddYears(-110));

            RuleFor(x => x.PhoneNumber)
                .Must(x => Regex.Match(x, @"^(\+[0-9]{9})$").Success);
        }
    }
}