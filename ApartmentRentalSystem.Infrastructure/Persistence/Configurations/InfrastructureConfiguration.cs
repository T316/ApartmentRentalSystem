namespace ApartmentRentalSystem.Infrastructure.Persistence.Configurations
{
    using ApartmentRentalSystem.Application.Contracts;
    using ApartmentRentalSystem.Infrastructure.Persistence.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddDbContext<ApartmentRentalDbContext>(option => option
                .UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApartmentRentalDbContext).Assembly.FullName)))
                .AddTransient(typeof(IRepository<>), typeof(DataRepository<>));
    }
}
