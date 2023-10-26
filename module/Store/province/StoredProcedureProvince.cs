using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class StoreProvince
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }

    [StringLength(200)]
    public string? NAMETH { get; set; }

    [StringLength(200)]
    public string? NAMEEN { get; set; }

    [StringLength(2)]
    public string? PROVINCE_ABBR { get; set; }
}