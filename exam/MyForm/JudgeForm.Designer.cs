namespace exam.MyForm
{
    partial class JudgeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JudgeForm));
            this.button1 = new System.Windows.Forms.Button();
            this.errorLabel = new System.Windows.Forms.Label();
            this.content = new System.Windows.Forms.Label();
            this.right = new System.Windows.Forms.RadioButton();
            this.wrong = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button1.Location = new System.Drawing.Point(772, 323);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 46);
            this.button1.TabIndex = 20;
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
            this.errorLabel.Location = new System.Drawing.Point(745, 26);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(133, 83);
            this.errorLabel.TabIndex = 19;
            // 
            // content
            // 
            this.content.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.content.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.content.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.content.Location = new System.Drawing.Point(12, 26);
            this.content.Name = "content";
            this.content.Size = new System.Drawing.Size(727, 551);
            this.content.TabIndex = 18;
            this.content.Text = "没有题目";
            // 
            // right
            // 
            this.right.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.right.AutoSize = true;
            this.right.Cursor = System.Windows.Forms.Cursors.Default;
            this.right.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.right.Location = new System.Drawing.Point(820, 171);
            this.right.Name = "right";
            this.right.Size = new System.Drawing.Size(58, 20);
            this.right.TabIndex = 21;
            this.right.TabStop = true;
            this.right.Text = "正确";
            this.right.UseVisualStyleBackColor = true;
            // 
            // wrong
            // 
            this.wrong.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.wrong.AutoSize = true;
            this.wrong.Cursor = System.Windows.Forms.Cursors.Default;
            this.wrong.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.wrong.Location = new System.Drawing.Point(820, 232);
            this.wrong.Name = "wrong";
            this.wrong.Size = new System.Drawing.Size(58, 20);
            this.wrong.TabIndex = 22;
            this.wrong.TabStop = true;
            this.wrong.Text = "错误";
            this.wrong.UseVisualStyleBackColor = true;
            // 
            // JudgeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.ClientSize = new System.Drawing.Size(890, 586);
            this.Controls.Add(this.wrong);
            this.Controls.Add(this.right);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.content);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "JudgeForm";
            this.Text = "判断题";
            this.Load += new System.EventHandler(this.JudgeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Label content;
        private System.Windows.Forms.RadioButton right;
        private System.Windows.Forms.RadioButton wrong;
    }
}