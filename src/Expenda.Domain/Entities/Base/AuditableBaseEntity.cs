namespace Expenda.Domain.Entities.Base;

public abstract class AuditableBaseEntity : BaseEntity
{
    public DateTime CreatedTimestamp { get; set; }

    public int CreatedById { get; set; }

    public DateTime LastUpdatedTimestamp { get; set; }

    public int LastUpdatedById { get; set; }
}
