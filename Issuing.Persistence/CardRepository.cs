using Issuing.Domain.Entities;
using Issuing.Domain.Interfaces.Repos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Issuing.Persistence
{
    public class CardRepository : GenericRepository<Card>, ICardRepository
    {
        public CardRepository(StoreContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Card>> GetPassiveCards()
        {
            return await Find(c => c.Status == 0);
        }

    }
}
