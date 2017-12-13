using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String tendn = textBox1.Text;
            String mk = textBox2.Text;
            int a = BUS.QLTK_BUS.login(tendn, mk);
            if (a == 0)
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (a == 3)
                MessageBox.Show("Tài khoản bị khoá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (a == 1)
                {
                    Admin a1 = new Admin();
                    a1.Closed += (s, args) => this.Close();
                    a1.Show();
                    Hide();
                }
                if (a == 2)
                {
                    User a1 = new User();
                    a1.Closed += (s, args) => this.Close();
                    a1.Show();
                    Hide();
                }
            }
        }


    }
}
