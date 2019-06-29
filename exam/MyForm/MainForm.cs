using exam.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exam.MyForm
{
    public partial class MainForm : Form
    {
        private static ChoiceForm choiceForm = null;
        private static MultipleChoiceForm multipleChoiceForm = null;
        private static JudgeForm judgeForm = null;

        private Form currentForm;

        public MainForm()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void 导入单选题ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Title = "请选择题库文件";
            dialog.Filter = "所有文件(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string name = dialog.FileName;

                ExcelHelper.ImportChoiceQuestion(name);
                MessageBox.Show("导入成功");
            }
        }

        private void 导入多选题ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Title = "请选择题库文件";
            dialog.Filter = "所有文件(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string name = dialog.FileName;

                ExcelHelper.ImportMultipleChoiceQuestion(name);
                MessageBox.Show("导入成功");
            }
        }

        private void 导入判断题ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Title = "请选择题库文件";
            dialog.Filter = "所有文件(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string name = dialog.FileName;

                ExcelHelper.ImportJudgeQuestion(name);
                MessageBox.Show("导入成功");
            }
        }

        public void ShowForm(Panel panel,Form frm)
        {
            lock(this)
            {
                try
                {
                    if (this.currentForm != null && this.currentForm == frm)
                    {
                        return;
                    }
                    else if (this.currentForm != null)
                    {
                        if (this.ActiveMdiChild != null)
                        {
                            this.ActiveMdiChild.Close();
                        }
                    }
                    this.currentForm = frm;
                    frm.TopLevel = false;
                    frm.MdiParent = this;
                    frm.Show();
                    frm.Dock = System.Windows.Forms.DockStyle.Fill;
                    this.Refresh();
                    foreach (Control item in frm.Controls)
                    {
                        item.Focus();
                        break;
                    }
                }
                catch(Exception ex)
                {
                    Console.Write(ex.Message);
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void 单选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            choiceForm = new ChoiceForm
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };
            choiceForm.SetExamType(QuestionHistory.EXAM_TYPE_UNDO);
            choiceForm.Show();
        }

        private void 多选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            multipleChoiceForm = new MultipleChoiceForm
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };
            multipleChoiceForm.SetExamType(QuestionHistory.EXAM_TYPE_UNDO);
            multipleChoiceForm.Show();
        }

        private void 判断ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            judgeForm = new JudgeForm
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };
            judgeForm.SetExamType(QuestionHistory.EXAM_TYPE_UNDO);
            judgeForm.Show();
        }

        private void 版本信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutMe from = new AboutMe();
            from.Show();
        }

        private void 单选ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            choiceForm = new ChoiceForm
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };
            choiceForm.SetExamType(QuestionHistory.EXAM_TYPE_WRONG);
            choiceForm.Show();
        }

        private void 多选ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            multipleChoiceForm = new MultipleChoiceForm
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };
            multipleChoiceForm.SetExamType(QuestionHistory.EXAM_TYPE_WRONG);
            multipleChoiceForm.Show();
        }

        private void 判断ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            judgeForm = new JudgeForm
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };
            judgeForm.SetExamType(QuestionHistory.EXAM_TYPE_WRONG);
            judgeForm.Show();
        }

        private void 单选ToolStripMenuItem2_Click(object sender, EventArgs e)
        {

            choiceForm = new ChoiceForm
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };
            choiceForm.SetExamType(QuestionHistory.EXAM_TYPE_REVIEW);
            choiceForm.Show();
        }

        private void 多选ToolStripMenuItem2_Click(object sender, EventArgs e)
        {

            multipleChoiceForm = new MultipleChoiceForm
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };
            multipleChoiceForm.SetExamType(QuestionHistory.EXAM_TYPE_REVIEW);
            multipleChoiceForm.Show();
        }

        private void 判断ToolStripMenuItem2_Click(object sender, EventArgs e)
        {

            judgeForm = new JudgeForm
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };
            judgeForm.SetExamType(QuestionHistory.EXAM_TYPE_REVIEW);
            judgeForm.Show();
        }

        private void 查看题库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProblemListForm problemListForm = new ProblemListForm
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };
            problemListForm.Show();
        }

        private void 开始训练ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
