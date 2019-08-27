using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hiker.Persistence.DAO;

namespace Hiker.Persistence.Repositories.Interfaces
{
    public interface IMountainsRepository
    {
        Task<List<Mountain>> GetAllAsync();
    }
}