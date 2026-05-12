using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bt1
{
    public partial class f_OTP : Form
    {
        // 1. Thêm biến 'to' để nhận email từ form f_Register truyền sang
        public string to;

        public f_OTP()
        {
            InitializeComponent();
        }

        // 2. Hàm này dùng để giả lập việc nhập đúng mã OTP
        // (Bạn cần kéo 1 Button vào form f_OTP, đổi Name thành btn_XacNhanOTP rồi nhấp đúp vào nó để sinh ra sự kiện này)
        private void btn_XacNhanOTP_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK; // Báo hiệu cho f_Register biết là OTP đã đúng
            this.Close(); // Đóng form OTP
        }
    }
}
