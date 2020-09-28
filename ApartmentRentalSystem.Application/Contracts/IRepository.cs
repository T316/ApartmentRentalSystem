namespace ApartmentRentalSystem.Application.Contracts
{
    using ApartmentRentalSystem.Domain.Common;

    public interface IRepository<out TEntity> 
        where TEntity : IAggregateRoot
    {
    }
}
