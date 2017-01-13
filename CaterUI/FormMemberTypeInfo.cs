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
    public partial class FormMemberTypeInfo : Form
    {
        public FormMemberTypeInfo()
        {
            InitializeComponent();
        }

        MemberTypeInfoBll bll = new MemberTypeInfoBll();
        private DialogResult _result = DialogResult.Cancel;

        private void FormMemberTypeInfo_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource = bll.GetList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MemberTypeInfo mti = new MemberTypeInfo()
            {
                MType = txtType.Text,
                MDiscount = Convert.ToDecimal(txtDiscount.Text)
            };
            if (txtId.Text.Equals(""))
            {
                if (bll.Add(mti))
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
                mti.MId = int.Parse(txtId.Text);
                if (bll.Edit(mti))
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("Update failure, please try again later");
                }
            }
            txtId.Text = "";
            txtType.Text = "";
            txtDiscount.Text = "";
            btnSave.Text = "Add";
            _result = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtType.Text = "";
            txtDiscount.Text = "";
            btnSave.Text = "Add";
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvList.Rows[e.RowIndex];
            txtId.Text = row.Cells[0].Value.ToString();
            txtType.Text = row.Cells[1].Value.ToString();
            txtDiscount.Text = row.Cells[2].Value.ToString();
            btnSave.Text = "Edit";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var row = dgvList.SelectedRows[0];
            int id = Convert.ToInt32(row.Cells[0].Value);
            DialogResult result = MessageBox.Show("Are you sure to delete?", "Message", MessageBoxButtons.OKCancel);
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
            _result = DialogResult.OK;
        }

        private void FormMemberTypeInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = _result;
        }
    }
}
