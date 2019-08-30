using System.Collections;
using System.Collections.Generic;
using Hiker.Persistence.DAO;
using MediatR;

namespace Hiker.Application.Features.Mountains.Queries.GellMountains
{
    public class GetMountainsQuery : IRequest<IEnumerable<Mountain>>
    {
        
    }
}