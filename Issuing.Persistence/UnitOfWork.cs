using Issuing.Domain;
using Issuing.Domain.Interfaces;
using Issuing.Domain.Interfaces.Repos;
using System.Threading.Tasks;

namespace Issuing.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext _context;
        private ICardRepository _cardRepository;

        public UnitOfWork(StoreContext context)
        {
            _context = context;
        }

        public ICardRepository Cards
        {
            get
            {
                if (_cardRepository == null)
                {
                    _cardRepository = new CardRepository(_context);
                }
                return _cardRepository;
            }
        }

        public async Task<int> CompleteAsync()
        {
            var result =  await _context.SaveChangesAsync();
            return result;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
