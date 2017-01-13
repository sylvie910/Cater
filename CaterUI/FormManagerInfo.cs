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
    public partial class FormManagerInfo : Form
    {
        ManagerInfoBll bll = new ManagerInfoBll();
        private FormManagerInfo()
        {
            InitializeComponent();
        }

        private static FormManagerInfo _formManagerInfo;

        public static FormManagerInfo Create()
        {
            return _formManagerInfo ?? (_formManagerInfo = new FormManagerInfo());
        }

        private void FormManagerInfo_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource = bll.GetList();
        }

        private void dgvList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                e.Value = Convert.ToInt32(e.Value) == 1 ? "Manager" : "Employee";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ManagerInfo mi = new ManagerInfo()
            {
                MName = txtName.Text,
                MPwd = txtPwd.Text,
                MType = rb1.Checked ? 1 : 0
            };
            if (btnAdd.Text.Equals("Add"))
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
            }
            txtName.Text = "";
            txtPwd.Text = "";
            rb2.Checked = true;
            btnAdd.Text = "Add";
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvList.Rows[e.RowIndex];
            txtId.Text = row.Cells[0].Value.ToString();
            txtName.Text = row.Cells[1].Value.ToString();
            if (row.Cells[2].Value.ToString().Equals("1"))
            {
                rb1.Checked = true;
            }
            else
            {
                rb2.Checked = true;
            }
            txtPwd.Text = "original?";
            btnAdd.Text = "Edit";
        }

        private void txtPwd_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtPwd.Text = "";
            rb2.Checked = true;
            btnAdd.Text = "Add";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var rows = dgvList.SelectedRows;
            if (rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure to delete?", "Message", MessageBoxButtons.OKCancel);
                if (result == DialogResult.Cancel)
                {
                    return;
                }
                int id = int.Parse(rows[0].Cells[0].Value.ToString());
                if (bll.Remove(id))
                {
                    LoadList();
                }
            }
            else
            {
                MessageBox.Show("Please select one row");
            }
        }

        private void FormManagerInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            _formManagerInfo = null;
        }
    }
}
