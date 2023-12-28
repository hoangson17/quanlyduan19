using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppQuanly
{
    public partial class TraHang : Form
    {
        public TraHang()
        {
            InitializeComponent();
        }
        Modify modify;
        trahang1 traHang;
        private void TraHang_Load(object sender, EventArgs e)
        {
            modify = new Modify();
            try
            {
                guna2DataGridView1.DataSource = modify.getAllTrahang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button_them_Click(object sender, EventArgs e)
        {
            string sopn = this.guna2TextBox_sopt.Text;
            DateTime ngaytra = this.guna2DateTimePicker_ngaytra.Value;
            string httt = this.guna2TextBox_httt.Text;
            string manv = this.guna2TextBox_mnv.Text;
            string mancc = this.guna2TextBox_ncc.Text;
            traHang = new trahang1(sopn, ngaytra, httt, manv, mancc);
            if (modify.insertTrahang(traHang))
            {
                guna2DataGridView1.DataSource = modify.getAllTrahang();
            }
            else
            {
                MessageBox.Show("Lỗi " + "không thêm vào được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button_sua_Click(object sender, EventArgs e)
        {
            string sopn = this.guna2TextBox_sopt.Text;
            DateTime ngaytra = this.guna2DateTimePicker_ngaytra.Value;
            string httt = this.guna2TextBox_httt.Text;
            string manv = this.guna2TextBox_mnv.Text;
            string mancc = this.guna2TextBox_ncc.Text;
            traHang = new trahang1(sopn, ngaytra, httt, manv, mancc);
            if (modify.updateTrahang(traHang))
            {
                guna2DataGridView1.DataSource = modify.getAllTrahang();
            }
            else
            {
                MessageBox.Show("Lỗi " + "không sửa được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button_xoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có dòng nào được chọn không
                if (guna2DataGridView1.SelectedRows.Count > 0)
                {
                    // Lấy giá trị của cột đầu tiên (giả sử đó là cột ID) từ dòng được chọn
                    string id = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();

                    // Xác nhận xóa bằng MessageBox trước khi tiến hành xóa
                    DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa phiếu nhập có số : {id} không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Thực hiện xóa và kiểm tra kết quả
                        if (modify.deleteTrahang(id))
                        {
                            guna2DataGridView1.DataSource = modify.getAllTrahang();
                            MessageBox.Show("Xóa hóa phiếu trả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không xóa được phiếu trả. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một phiếu trả để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ChiTietTH chiTietTH = new ChiTietTH();
            chiTietTH.ShowDialog();
        }
    }
}
