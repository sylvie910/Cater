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
    public partial class FormDishTypeInfo : Form
    {
        public FormDishTypeInfo()
        {
            InitializeComponent();
        }
        DishTypeInfoBll dtiBll = new DishTypeInfoBll();
        private int rowIndex = -1;
        private DialogResult result = DialogResult.Cancel;

        private void FormDishTypeInfo_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource = dtiBll.GetList();
            if (rowIndex >= 0)
            {
                dgvList.Rows[rowIndex].Selected = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DishTypeInfo dti = new DishTypeInfo()
            {
                DTitle = txtTitle.Text
            };

            if (txtId.Text == "")
            {
                if (dtiBll.Add(dti))
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
                dti.DId = int.Parse(txtId.Text);
                if (dtiBll.Edit(dti))
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("Edit failure, please try again later");
                }
            }
            txtId.Text = "";
            txtTitle.Text = "";
            btnSave.Text = "Add";

            this.result = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtTitle.Text = "";
            btnSave.Text = "Add";
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvList.Rows[e.RowIndex];

            txtId.Text = row.Cells[0].Value.ToString();
            txtTitle.Text = row.Cells[1].Value.ToString();
            btnSave.Text = "Edit";

            rowIndex = e.RowIndex;
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

            if (dtiBll.Delete(id))
            {
                LoadList();
            }
            else
            {
                MessageBox.Show("Delete failure, please try again later");
            }
            rowIndex = 0;
            this.result = DialogResult.OK;
        }

        private void FormDishTypeInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = this.result;
        }
    }
}
