namespace AlexApps.ECommerce.Domain.Common;

public abstract class BaseEntity : IAuditableEntity, ISoftDeleteEntity
{
    public int Id { get; protected set; }
    public DateTime CreatedOnUtc { get; protected set; }
    public DateTime? ModifiedOnUtc { get; protected set; }
    public bool IsDeleted { get; protected set; }
    public DateTime? DeletedOnUtc { get; protected set; }
}