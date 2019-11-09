using System.Threading;
using System.Threading.Tasks;
using Hiker.Persistence.DAO;
using Hiker.Persistence.Repositories.Interfaces;
using MediatR;

namespace Hiker.Application.Features.Users.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, User>
    {
        private readonly IUserRepository _userRepository;

        public GetUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            return _userRepository.GetAsync(request.Predicate);
        }
    }
}