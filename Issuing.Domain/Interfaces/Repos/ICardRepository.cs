using Issuing.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Issuing.Domain.Interfaces.Repos
{
    public interface ICardRepository : IGenericRepository<Card>
    {
        public Task<IEnumerable<Card>> GetPassiveCards();

    

    }
}
