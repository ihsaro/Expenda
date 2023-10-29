namespace Expenda.Domain.Entities.Base;

public abstract class AuditableBaseEntity : BaseEntity
{
    public DateTime CreatedTimestamp { get; set; }

    public ApplicationUser CreatedBy { get; set; } = null!;

    public DateTime LastUpdatedTimestamp { get; set; }

    public ApplicationUser LastUpdatedBy { get; set; } = null!;
}
