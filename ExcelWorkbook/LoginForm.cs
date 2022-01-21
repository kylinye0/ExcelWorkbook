using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebApiContext.DAL;
using WebApiContext.Entity;



namespace ExcelWorkbook
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            checkBox1.Parent = pictureBox1;
           
            label2.Parent = pictureBox1;
            label3.Parent = pictureBox1;
            label4.Parent = pictureBox1;
            label5.Parent = pictureBox1;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserDao userdao = new UserDao();
            User user = userdao.GetDataByUserName(usercomboBox.Text,servcomboBox2.Text,dbcomboBox3.Text);
            if (user is null)
            {
                MessageBox.Show("不存在此用户");
            }
            else
            {
                if (user.PassWord.Trim() == pwtextBox1.Text.Trim())
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("用户或密码输入错误");
                }
            }
        }
    }
}
