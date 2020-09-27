namespace ApartmentRentalSystem.Domain.Factories
{
    using ApartmentRentalSystem.Domain.Common;

    public interface IFactory<out TEntity>
        where TEntity : IAggregateRoot
    {
        TEntity Build();
    }
}
