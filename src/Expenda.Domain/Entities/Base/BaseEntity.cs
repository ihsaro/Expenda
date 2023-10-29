using System.ComponentModel.DataAnnotations;

namespace Expenda.Domain.Entities.Base;

public abstract class BaseEntity
{
    [Key]
    public int Id { get; set; }
}