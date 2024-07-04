using Microsoft.AspNetCore.Identity;

namespace AlexApps.ECommerce.Domain.Common;

public class ApplicationUser : IdentityUser<int>, IAuditableEntity, ISoftDeleteEntity
{
    public ApplicationUser()
    {
        CreatedOnUtc = DateTime.UtcNow;
    }

    public string FirstName { get; protected set; }
    public string LastName { get; protected set; }
    public string FullName => $"{FirstName} {LastName}";

    public string? Street { get; protected set; }

    public string City { get; protected set; }

    public bool IsDeleted { get; protected set; }

    public DateTime? DeletedOnUtc { get; protected set; }

    public DateTime CreatedOnUtc { get; protected set; }

    public DateTime? ModifiedOnUtc { get; protected set; }
}