using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bt1
{
    public partial class f_AddStudent : Form
    {
        public f_AddStudent()
        {
            InitializeComponent();
        }
        byte[] studentImage = null;
        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picStudent.Image = Image.FromFile(ofd.FileName);
                // Chuyển ảnh sang byte array
                MemoryStream ms = new MemoryStream();
                picStudent.Image.Save(ms, picStudent.Image.RawFormat);
                studentImage = ms.ToArray();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMSSV.Text) || string.IsNullOrEmpty(txtLname.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ MSSV và Tên!", "Cảnh báo");
                return;
            }
            int mssv;
            if (!int.TryParse(txtMSSV.Text,out mssv))
            {
                MessageBox.Show("MSSV phải là số", "Cảnh báo");
                return;
            }
            if (dtpDob.Value.Date > DateTime.Now.Date)
            {
                MessageBox.Show("Ngày sinh phải nhỏ hơn ngày hiện tại", "Cảnh báo");
                return;
            }
            Student sv = new Student(
                int.Parse(txtMSSV.Text), txtFname.Text, txtLname.Text,
                dtpDob.Value, cboGender.Text, txtPhone.Text,
                txtAddress.Text, txtHometown.Text, txtEmail.Text, studentImage);

            if (sv.AddStudent())
                MessageBox.Show("Thêm sinh viên thành công!", "Thông báo");
            else
                MessageBox.Show("Thêm thất bại! MSSV có thể đã tồn tại.", "Lỗi");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMSSV.Clear();
            txtFname.Clear();
            txtLname.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            txtHometown.Clear();
            txtEmail.Clear();
            cboGender.SelectedIndex = -1;   
            dtpDob.Value = DateTime.Now;    
            picStudent.Image = null;        
        }

        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void f_AddStudent_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
