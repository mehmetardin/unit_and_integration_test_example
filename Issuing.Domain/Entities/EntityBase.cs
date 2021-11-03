namespace Issuing.Domain.Entities
{
    public class EntityBase<T> : IEntity<T>
    {
        public T Id { get; set; }
    }
}
