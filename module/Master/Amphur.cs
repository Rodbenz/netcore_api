using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("AMPHUR", Schema = "dbo")]
public class AMPHUR
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AMPHUR_SEQ { get; set; }

    [StringLength(255)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string? AMPHUR_CODE { get; set; }

    [StringLength(255)]
    public string? AMPHUR_Name { get; set; }

    [StringLength(10)]
    public string? PROVINCE_CODE { get; set; }

    // public string PROVINCE_CODE { get; set;}
}
