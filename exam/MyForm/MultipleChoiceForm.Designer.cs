namespace exam.MyForm
{
    partial class MultipleChoiceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultipleChoiceForm));
            this.button1 = new System.Windows.Forms.Button();
            this.errorLabel = new System.Windows.Forms.Label();
            this.content = new System.Windows.Forms.Label();
            this.aska = new System.Windows.Forms.CheckBox();
            this.askb = new System.Windows.Forms.CheckBox();
            this.askc = new System.Windows.Forms.CheckBox();
            this.askd = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(801, 211);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 47);
            this.button1.TabIndex = 13;
            this.button1.Text = "提交（正确进去下一题）";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // errorLabel
            // 
            this.errorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.errorLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.errorLabel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(766, 18);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(157, 92);
            this.errorLabel.TabIndex = 12;
            // 
            // content
            // 
            this.content.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.content.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.content.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.content.Location = new System.Drawing.Point(12, 18);
            this.content.Name = "content";
            this.content.Size = new System.Drawing.Size(733, 254);
            this.content.TabIndex = 7;
            this.content.Text = "没有题目";
            // 
            // aska
            // 
            this.aska.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.aska.AutoSize = true;
            this.aska.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.aska.Location = new System.Drawing.Point(12, 311);
            this.aska.Name = "aska";
            this.aska.Size = new System.Drawing.Size(91, 20);
            this.aska.TabIndex = 14;
            this.aska.Text = "没有题目";
            this.aska.UseVisualStyleBackColor = true;
            // 
            // askb
            // 
            this.askb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.askb.AutoSize = true;
            this.askb.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.askb.Location = new System.Drawing.Point(12, 371);
            this.askb.Name = "askb";
            this.askb.Size = new System.Drawing.Size(91, 20);
            this.askb.TabIndex = 15;
            this.askb.Text = "没有题目";
            this.askb.UseVisualStyleBackColor = true;
            // 
            // askc
            // 
            this.askc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.askc.AutoSize = true;
            this.askc.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.askc.Location = new System.Drawing.Point(12, 431);
            this.askc.Name = "askc";
            this.askc.Size = new System.Drawing.Size(91, 20);
            this.askc.TabIndex = 16;
            this.askc.Text = "没有题目";
            this.askc.UseVisualStyleBackColor = true;
            // 
            // askd
            // 
            this.askd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.askd.AutoSize = true;
            this.askd.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.askd.Location = new System.Drawing.Point(12, 495);
            this.askd.Name = "askd";
            this.askd.Size = new System.Drawing.Size(91, 20);
            this.askd.TabIndex = 17;
            this.askd.Text = "没有题目";
            this.askd.UseVisualStyleBackColor = true;
            // 
            // MultipleChoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.ClientSize = new System.Drawing.Size(947, 579);
            this.Controls.Add(this.askd);
            this.Controls.Add(this.askc);
            this.Controls.Add(this.askb);
            this.Controls.Add(this.aska);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.content);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MultipleChoiceForm";
            this.Text = "MultipleChoiceForm";
            this.Load += new System.EventHandler(this.MultipleChoiceForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Label content;
        private System.Windows.Forms.CheckBox aska;
        private System.Windows.Forms.CheckBox askb;
        private System.Windows.Forms.CheckBox askc;
        private System.Windows.Forms.CheckBox askd;
    }
}