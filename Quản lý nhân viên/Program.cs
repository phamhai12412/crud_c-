using System;
using System.Configuration; // Add this using statement
using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;
using Quản_lý_nhân_viên;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        var connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        var optionsBuilder = new DbContextOptionsBuilder<QLNVEntities>();
        optionsBuilder.UseSqlServer(connectionString);

        try
        {
            using (var context = new QLNVEntities(optionsBuilder.Options))
            {
                Application.Run(new Form1(context));
            }
        }
        catch (Microsoft.Data.SqlClient.SqlException ex)
        {
            for (int i = 0; i < ex.Errors.Count; i++)
            {
                Console.WriteLine($"Index #{i}: {ex.Errors[i]}");
            }
            Console.WriteLine($"Error Number: {ex.Number}, Message: {ex.Message}");

            // Add additional error handling if necessary
            // ...

            MessageBox.Show($"Lỗi kết nối đến cơ sở dữ liệu. Chi tiết: {ex.Message}");
        }
    }
}
