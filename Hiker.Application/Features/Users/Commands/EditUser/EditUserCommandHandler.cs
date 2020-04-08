using System;
using System.Threading;
using System.Threading.Tasks;
using Hiker.Application.Common.Exceptions;
using Hiker.Persistence.Repositories.Interfaces;
using MediatR;

namespace Hiker.Application.Features.Users.Commands.EditUser
{
    public class EditUserCommandHandler : IRequestHandler<EditUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;

        public EditUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(x => x.Id == request.UserId);
            if (user == null)
            {
                throw new EntityNotFoundException($"User with Id {request.UserId} doesn't exist.");
            }

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.AboutMe = request.AboutMe;
            user.PhoneNumber = request.PhoneNumber;
            user.Birthday = request.Birthday;

            if (!await _userRepository.UpdateUserAsync(user))
            {
                throw new UpdateRecordFailedException($"Failed updating user with Id {request.UserId}");
            }

            return user.Id;
        }
    }
}