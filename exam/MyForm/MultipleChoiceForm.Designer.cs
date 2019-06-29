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
            this.button1.Location = new System.Drawing.Point(734, 174);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 47);
            this.button1.TabIndex = 13;
            this.button1.Text = "提交（正确进去下一题）";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // errorLabel
            // 
            this.errorLabel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(711, 52);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(157, 92);
            this.errorLabel.TabIndex = 12;
            // 
            // content
            // 
            this.content.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.content.Location = new System.Drawing.Point(57, 52);
            this.content.Name = "content";
            this.content.Size = new System.Drawing.Size(587, 180);
            this.content.TabIndex = 7;
            this.content.Text = "label1";
            // 
            // aska
            // 
            this.aska.AutoSize = true;
            this.aska.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.aska.Location = new System.Drawing.Point(59, 277);
            this.aska.Name = "aska";
            this.aska.Size = new System.Drawing.Size(99, 20);
            this.aska.TabIndex = 14;
            this.aska.Text = "checkBox1";
            this.aska.UseVisualStyleBackColor = true;
            // 
            // askb
            // 
            this.askb.AutoSize = true;
            this.askb.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.askb.Location = new System.Drawing.Point(59, 337);
            this.askb.Name = "askb";
            this.askb.Size = new System.Drawing.Size(99, 20);
            this.askb.TabIndex = 15;
            this.askb.Text = "checkBox2";
            this.askb.UseVisualStyleBackColor = true;
            // 
            // askc
            // 
            this.askc.AutoSize = true;
            this.askc.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.askc.Location = new System.Drawing.Point(59, 397);
            this.askc.Name = "askc";
            this.askc.Size = new System.Drawing.Size(99, 20);
            this.askc.TabIndex = 16;
            this.askc.Text = "checkBox3";
            this.askc.UseVisualStyleBackColor = true;
            // 
            // askd
            // 
            this.askd.AutoSize = true;
            this.askd.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.askd.Location = new System.Drawing.Point(59, 461);
            this.askd.Name = "askd";
            this.askd.Size = new System.Drawing.Size(99, 20);
            this.askd.TabIndex = 17;
            this.askd.Text = "checkBox4";
            this.askd.UseVisualStyleBackColor = true;
            // 
            // MultipleChoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 579);
            this.Controls.Add(this.askd);
            this.Controls.Add(this.askc);
            this.Controls.Add(this.askb);
            this.Controls.Add(this.aska);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.content);
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