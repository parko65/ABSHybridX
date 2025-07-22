using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;
public class Aggregate
{
    [Column("AggregateId")]
    public int Id { get; set; }

    public string? Name { get; set; }
    public int? HotBinId { get; set; }
    public HotBin? HotBin { get; set; }
}
