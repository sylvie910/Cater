using System;
using System.Collections;
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
    public partial class FormMemberInfo : Form
    {
        public FormMemberInfo()
        {
            InitializeComponent();
        }
        MemberInfoBll bll = new MemberInfoBll();

        private void FormMemberInfo_Load(object sender, EventArgs e)
        {
            LoadList();
            LoadTypeList();
        }

        private void LoadTypeList()
        {
            MemberTypeInfoBll bll = new MemberTypeInfoBll();
            IList<MemberTypeInfo> list = bll.GetList();
            ddlType.DataSource = list;
            ddlType.DisplayMember = "MType";
            ddlType.ValueMember = "MId";
        }

        private void LoadList()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            if (txtNameSearch.Text != "")
            {
                dictionary.Add("mname", txtNameSearch.Text);
            }
            if (txtPhoneSearch.Text != "")
            {
                dictionary.Add("mphone", txtPhoneSearch.Text);
            }
            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource = bll.GetList(dictionary);
            if (_dgvSelectedIndex>-1)
            {
                dgvList.Rows[_dgvSelectedIndex].Selected = true;
            }
        }

        private void txtNameSearch_TextChanged(object sender, EventArgs e)
        {
            LoadList();
        }

        private void txtPhoneSearch_TextChanged(object sender, EventArgs e)
        {
            LoadList();
        }


        private void btnSearchAll_Click(object sender, EventArgs e)
        {
            txtNameSearch.Text = "";
            txtPhoneSearch.Text = "";
            LoadList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNameAdd.Text == "")
            {
                MessageBox.Show("Please input the user name");
                txtNameAdd.Focus();
                return;
            }
            MemberInfo mi = new MemberInfo()
            {
                MName = txtNameAdd.Text,
                MPhone = txtPhoneAdd.Text,
                MMoney = Convert.ToDecimal(txtMoney.Text),
                MTypeId = Convert.ToInt32(ddlType.SelectedValue)
            };
            if (txtId.Text.Equals(""))
            {
                if (bll.Add(mi))
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("Insert failure, please try again later");
                }
            }
            else
            {
                mi.MId = int.Parse(txtId.Text);
                if (bll.Edit(mi))
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("Edit failure, please try again later");
                }
            }
            txtId.Text = "";
            txtNameAdd.Text = "";
            txtPhoneAdd.Text = "";
            txtMoney.Text = "";
            ddlType.SelectedIndex = 0;
            btnSave.Text = "Add";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtNameAdd.Text = "";
            txtPhoneAdd.Text = "";
            txtMoney.Text = "";
            ddlType.SelectedIndex = 0;
            btnSave.Text = "Add";
        }
        private int _dgvSelectedIndex = -1;
        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _dgvSelectedIndex = e.RowIndex;
            var row = dgvList.Rows[e.RowIndex];
            txtId.Text = row.Cells[0].Value.ToString();
            txtNameAdd.Text = row.Cells[1].Value.ToString();
            ddlType.Text = row.Cells[2].Value.ToString();
            txtPhoneAdd.Text = row.Cells[3].Value.ToString();
            txtMoney.Text = row.Cells[4].Value.ToString();
            btnSave.Text = "Edit";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvList.SelectedRows[0].Cells[0].Value);
            DialogResult result = MessageBox.Show("Are you sure to delete", "Message", MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel)
            {
                return;
            }
            if (bll.Remove(id))
            {
                LoadList();
            }
            else
            {
                MessageBox.Show("Delete failure, please try again later");
            }
        }

        private void btnAddType_Click(object sender, EventArgs e)
        {
            FormMemberTypeInfo formMti = new FormMemberTypeInfo();
            DialogResult result = formMti.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadTypeList();
                LoadList();
            }
        }
    }
}
