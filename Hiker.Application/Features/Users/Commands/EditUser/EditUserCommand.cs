using System;
using MediatR;

namespace Hiker.Application.Features.Users.Commands.EditUser
{
    public class EditUserCommand : IRequest<Guid>
    {
        public Guid UserId { get; }
        public string FirstName { get;}
        public string LastName { get; }
        public DateTime Birthday { get; }
        public string AboutMe { get; }
        public string PhoneNumber { get; }

        public EditUserCommand(Guid userId, string firstName, string lastName, DateTime birthday, string aboutMe, string phoneNumber)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            AboutMe = aboutMe;
            PhoneNumber = phoneNumber;
        }
    }
}