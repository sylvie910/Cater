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
    public partial class FormHallInfo : Form
    {
        private HallInfoBll hiBll;
        public event Action MyUpdateForm;//no return value, no parameter
        public FormHallInfo()
        {
            InitializeComponent();
            hiBll = new HallInfoBll();
        }

        private void FormHallInfo_Load(object sender, EventArgs e)
        {
            LoadList();
        }
        private void LoadList()
        {
            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource = hiBll.GetList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            HallInfo hi = new HallInfo()
            {
                HTitle = txtTitle.Text
            };

            if (txtId.Text == "")
            {
                if (hiBll.Add(hi))
                {
                    LoadList();
                }
            }
            else
            {
                hi.HId = int.Parse(txtId.Text);
                if (hiBll.Edit(hi))
                {
                    LoadList();
                }
            }

            txtId.Text = "";
            txtTitle.Text = "";
            btnSave.Text = "Add";

            MyUpdateForm();
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
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvList.SelectedRows[0].Cells[0].Value);
            DialogResult result = MessageBox.Show("Are you sure to delete?", "Message", MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            if (hiBll.Remove(id))
            {
                LoadList();
            }
            MyUpdateForm();
        }
    }
}
