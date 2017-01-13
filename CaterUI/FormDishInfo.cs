﻿using System;
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
    public partial class FormDishInfo : Form
    {
        public FormDishInfo()
        {
            InitializeComponent();
        }
        private DishInfoBll diBll = new DishInfoBll();
        private void FormDishInfo_Load(object sender, EventArgs e)
        {
            LoadTypeList();
            LoadList();
        }

        private void LoadList()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            if (txtTitleSearch.Text != "")
            {
                dic.Add("dtitle", txtTitleSearch.Text);
            }
            if (ddlTypeSearch.SelectedValue.ToString() != "0")
            {
                dic.Add("DTypeId", ddlTypeSearch.SelectedValue.ToString());
            }


            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource = diBll.GetList(dic);
        }

        private void LoadTypeList()
        {
            DishTypeInfoBll dtiBll = new DishTypeInfoBll();

            IList<DishTypeInfo> list = dtiBll.GetList();
            list.Insert(0, new DishTypeInfo()
            {
                DId = 0,
                DTitle = "All"
            });

            ddlTypeSearch.DataSource = list;
            ddlTypeSearch.ValueMember = "did";
            ddlTypeSearch.DisplayMember = "dtitle";

            ddlTypeAdd.DataSource = dtiBll.GetList();
            ddlTypeAdd.DisplayMember = "dtitle";
            ddlTypeAdd.ValueMember = "did";
        }

        private void txtTitleSearch_TextChanged(object sender, EventArgs e)
        {
            LoadList();
        }

        private void ddlTypeSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadList();
        }
        private void btnSearchAll_Click(object sender, EventArgs e)
        {
            txtTitleSearch.Text = "";
            ddlTypeSearch.SelectedIndex = 0;
            LoadList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DishInfo di = new DishInfo()
            {
                DTitle = txtTitleSave.Text,
                DPrice = Convert.ToDecimal(txtPrice.Text),
                DTypeId = Convert.ToInt32(ddlTypeAdd.SelectedValue)
            };

            if (txtId.Text == "")
            {
                if (diBll.Add(di))
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
                di.DId = int.Parse(txtId.Text);
                if (diBll.Update(di))
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("Edit failure, please try again later");
                }
            }

            txtId.Text = "";
            txtTitleSave.Text = "";
            txtPrice.Text = "";
            ddlTypeAdd.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtId.Text = "添加时无编号";
            txtTitleSave.Text = "";
            txtPrice.Text = "";
            ddlTypeAdd.SelectedIndex = 0;
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvList.Rows[e.RowIndex];
            txtId.Text = row.Cells[0].Value.ToString();
            txtTitleSave.Text = row.Cells[1].Value.ToString();
            ddlTypeAdd.Text = row.Cells[2].Value.ToString();
            txtPrice.Text = row.Cells[3].Value.ToString();
            btnSave.Text = "Edit";
        }

        private void btnAddType_Click(object sender, EventArgs e)
        {
            FormDishTypeInfo formDti = new FormDishTypeInfo();
            DialogResult result = formDti.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadTypeList();
                LoadList();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvList.SelectedRows[0].Cells[0].Value);
            DialogResult result = MessageBox.Show("Are you sure to delete", "Message", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                if (diBll.Remove(id))
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("****");
                }
            }
        }
    }
}
