﻿namespace CaterUI
{
    partial class FormMemberTypeInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvList);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 265);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Membership List";
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(3, 16);
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(348, 246);
            this.dgvList.TabIndex = 0;
            this.dgvList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellDoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRemove);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.txtDiscount);
            this.groupBox2.Controls.Add(this.txtType);
            this.groupBox2.Controls.Add(this.txtId);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(372, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(183, 256);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add/Edit";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(11, 213);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(166, 27);
            this.btnRemove.TabIndex = 18;
            this.btnRemove.Text = "Delete Selected Row";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(43, 186);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Double Click to Edit";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(101, 142);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 27);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(55, 96);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(116, 20);
            this.txtDiscount.TabIndex = 6;
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(55, 60);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(116, 20);
            this.txtType.TabIndex = 5;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(55, 22);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(116, 20);
            this.txtId.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(11, 142);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(70, 27);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Add";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Discount:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Type:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID:";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "mId";
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "mType";
            this.Column2.HeaderText = "Type";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "mDiscount";
            this.Column3.HeaderText = "Discount";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // FormMemberTypeInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 284);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "FormMemberTypeInfo";
            this.Text = "Membership Management";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMemberTypeInfo_FormClosing);
            this.Load += new System.EventHandler(this.FormMemberTypeInfo_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}