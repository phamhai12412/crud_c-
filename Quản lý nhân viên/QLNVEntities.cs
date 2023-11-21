using Microsoft.EntityFrameworkCore;
using Quản_lý_nhân_viên;

public class QLNVEntities : DbContext
{
    public DbSet<NhanVien> NhanViens { get; set; }

    public QLNVEntities(DbContextOptions<QLNVEntities> options)
        : base(options)
    {
    }
}