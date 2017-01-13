using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CaterBll;
using CaterModel;

namespace CaterUI
{
    public partial class FormLogin : Form
    {
        ManagerInfoBll bll = new ManagerInfoBll();
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string pwd = txtPwd.Text;
            int type;
            LoginState loginState= bll.Login(name, pwd,out type);
            if (loginState==LoginState.Ok)
            {
                FormMain main = new FormMain {Tag = type};
                main.Show();
                this.Hide();
            }else if (loginState==LoginState.NameError)
            {
                MessageBox.Show("The username does not match");
            }
            else if (loginState==LoginState.PwdError)
            {
                MessageBox.Show("The Password does not match");
            }
        }
    }
}
