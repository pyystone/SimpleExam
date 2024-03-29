﻿namespace exam.MyForm
{
    partial class ProblemListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProblemListForm));
            this.problemListView = new System.Windows.Forms.ListView();
            this.problemtype = new System.Windows.Forms.ComboBox();
            this.type = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // problemListView
            // 
            this.problemListView.BackColor = System.Drawing.Color.LightGreen;
            this.problemListView.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.problemListView.FullRowSelect = true;
            this.problemListView.GridLines = true;
            this.problemListView.Location = new System.Drawing.Point(29, 62);
            this.problemListView.Name = "problemListView";
            this.problemListView.Size = new System.Drawing.Size(1505, 773);
            this.problemListView.TabIndex = 0;
            this.problemListView.UseCompatibleStateImageBehavior = false;
            this.problemListView.View = System.Windows.Forms.View.Details;
            this.problemListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.problemListView_MouseDoubleClick);
            // 
            // problemtype
            // 
            this.problemtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.problemtype.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.problemtype.FormattingEnabled = true;
            this.problemtype.Location = new System.Drawing.Point(49, 25);
            this.problemtype.Name = "problemtype";
            this.problemtype.Size = new System.Drawing.Size(121, 24);
            this.problemtype.TabIndex = 1;
            this.problemtype.SelectedIndexChanged += new System.EventHandler(this.problemtype_SelectedIndexChanged);
            // 
            // type
            // 
            this.type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.type.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.type.FormattingEnabled = true;
            this.type.Location = new System.Drawing.Point(218, 25);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(121, 24);
            this.type.TabIndex = 2;
            this.type.SelectedIndexChanged += new System.EventHandler(this.type_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(398, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "双击单元格可以复制内容";
            // 
            // ProblemListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.ClientSize = new System.Drawing.Size(1557, 847);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.type);
            this.Controls.Add(this.problemtype);
            this.Controls.Add(this.problemListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProblemListForm";
            this.Text = "查询题库";
            this.Load += new System.EventHandler(this.ProblemListForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView problemListView;
        private System.Windows.Forms.ComboBox problemtype;
        private System.Windows.Forms.ComboBox type;
        private System.Windows.Forms.Label label1;
    }
}