using System.ComponentModel.DataAnnotations;

namespace Expenda.Domain.Entities;

public abstract class BaseEntity
{
    [Key]
    public int Id { get; set; }

    public DateTime CreatedTimestamp { get; set; }

    public DateTime LastUpdatedTimestamp { get; set; }
}