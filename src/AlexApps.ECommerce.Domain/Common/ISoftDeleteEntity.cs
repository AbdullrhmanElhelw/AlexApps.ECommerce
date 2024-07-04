namespace AlexApps.ECommerce.Domain.Common;

public interface ISoftDeleteEntity
{
    bool IsDeleted { get; }
    DateTime? DeletedOnUtc { get; }
}