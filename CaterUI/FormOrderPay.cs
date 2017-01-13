using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CaterBll;
using CaterModel;

namespace CaterUI
{
    public partial class FormOrderPay : Form
    {
        public FormOrderPay()
        {
            InitializeComponent();
        }
        private OrderInfoBll oiBll = new OrderInfoBll();
        private int orderId;
        public event Action Refresh;
        private void FormOrderPay_Load(object sender, EventArgs e)
        {
            orderId = Convert.ToInt32(this.Tag);
            gbMember.Enabled = false;
            GetMoneyByOrderId();
        }
        private void GetMoneyByOrderId()
        {
            lblPayMoney.Text = lblPayMoneyDiscount.Text = oiBll.GetTotalMoneyByOrderId(orderId).ToString();
        }

        private void cbkMember_CheckedChanged(object sender, EventArgs e)
        {
            gbMember.Enabled = cbkMember.Checked;
        }
        private void LoadMember()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            if (txtId.Text != "")
            {
                dic.Add("mid", txtId.Text);
            }
            if (txtPhone.Text != "")
            {
                dic.Add("mPhone", txtPhone.Text);
            }

            MemberInfoBll miBll = new MemberInfoBll();
            var list = miBll.GetList(dic);
            if (list.Count > 0)
            {
                MemberInfo mi = list[0];
                lblMoney.Text = mi.MMoney.ToString();
                lblTypeTitle.Text = mi.MTypeTitle;
                lblDiscount.Text = mi.MDiscount.ToString();

                lblPayMoneyDiscount.Text =
                    (Convert.ToDecimal(lblPayMoney.Text) * Convert.ToDecimal(lblDiscount.Text)).ToString();
            }
            else
            {
                MessageBox.Show("Wrong information!");
            }
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            LoadMember();
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            LoadMember();
        }
        private void cbkMoney_CheckedChanged(object sender, EventArgs e)
        {
            if (cbkMoney.Checked)
            {
                int balance = int.Parse(lblPayMoney.Text) - int.Parse(lblMoney.Text);
                if (balance<0)
                {
                    lblPayMoneyDiscount.Text = "0";
                    lblMoney.Text = (-balance).ToString();
                }
                else
                {
                    lblPayMoneyDiscount.Text = balance.ToString();
                }
            }
            else
            {
                LoadMember();
            }
        }
        private void btnOrderPay_Click(object sender, EventArgs e)
        {
            if (oiBll.Pay(cbkMoney.Checked, int.Parse(txtId.Text), Convert.ToDecimal(lblPayMoneyDiscount.Text), orderId,
                Convert.ToDecimal(lblDiscount.Text)))
            {
                Refresh();
                this.Close();
            }
            else
            {
                MessageBox.Show("Check out failure");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
