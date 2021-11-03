using Issuing.Domain.Interfaces.Repos;
using System;
using System.Threading.Tasks;

namespace Issuing.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICardRepository Cards { get; }
        Task<int> CompleteAsync();
    }
}
