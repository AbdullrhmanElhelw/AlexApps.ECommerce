namespace AlexApps.ECommerce.Application;

public interface IECommerceDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default!);
}