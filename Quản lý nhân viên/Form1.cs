namespace Quản_lý_nhân_viên
{
    public partial class Form1 : Form
    {
        private readonly QLNVEntities context;

        // Constructor with parameter to accept QLNVEntities from DI container
        public Form1(QLNVEntities context)
        {
            InitializeComponent();
            this.context = context;
            load(); // Make sure to call load method when the form is initialized
        }


        private void load()
        {
            try
            {
                if (context != null)
                {
                    var nhanViens = context.NhanViens.ToList();
                    dataGridView1.DataSource = nhanViens;

                }
                else
                {
                    MessageBox.Show("Không thể tải dữ liệu vì 'context' là null.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}\nStackTrace: {ex.StackTrace}");
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (DateTime.TryParse(txtNS.Text, out DateTime namSinh))
            {
                var nhanVien = new NhanVien
                {

                    HoTen = txtHT.Text,
                    NamSinh = namSinh,
                    ChucVu = txtCV.Text
                };

                context.NhanViens.Add(nhanVien);
                context.SaveChanges();
                load();
            }
            else
            {
                MessageBox.Show("Giá trị không hợp lệ cho MaNV hoặc NamSinh");
            }
        }

        private void btnReset_Click_1(object sender, EventArgs e)
        {

            txtHT.ResetText();
            txtNS.ResetText();
            txtCV.ResetText();
        }
    }
}