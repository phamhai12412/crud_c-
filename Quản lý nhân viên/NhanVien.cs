using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class NhanVien
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MaNV { get; set; }

    public string? HoTen { get; set; }

    [Column(TypeName = "Date")]
    [Required]
    public DateTime NamSinh { get; set; }

    public string? ChucVu { get; set; }
}
