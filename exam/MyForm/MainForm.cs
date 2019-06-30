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

        private Form currentForm;
        private int problemKind = QuestionHistory.TYPE_CHOICE;
        private int examType = QuestionHistory.EXAM_TYPE_UNDO;

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

        public void ShowForm()
        {
            if (currentForm != null )
            {
                currentForm.Close();
            }
            switch(problemKind)
            {
                case QuestionHistory.TYPE_CHOICE:
                    currentForm = new ChoiceForm
                    {
                        MdiParent = this,
                        WindowState = FormWindowState.Maximized
                    };
                    ((ChoiceForm)currentForm).SetExamType(examType);
                    currentForm.Show();
                    break;
                case QuestionHistory.TYPE_MULTIPLECHOICE:
                    currentForm = new MultipleChoiceForm
                    {
                        MdiParent = this,
                        WindowState = FormWindowState.Maximized
                    };
                    ((MultipleChoiceForm)currentForm).SetExamType(examType);
                    currentForm.Show();
                    break;
                case QuestionHistory.TYPE_JUDGE:
                    currentForm = new JudgeForm
                    {
                        MdiParent = this,
                        WindowState = FormWindowState.Maximized
                    };
                    ((JudgeForm)currentForm).SetExamType(examType);
                    currentForm.Show();
                    break;
            }
            currentForm.Dock = DockStyle.Fill;
            this.Refresh();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void 单选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            examType = QuestionHistory.EXAM_TYPE_UNDO;
            problemKind = QuestionHistory.TYPE_CHOICE;
            ShowForm();
        }

        private void 多选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            examType = QuestionHistory.EXAM_TYPE_UNDO;
            problemKind = QuestionHistory.TYPE_MULTIPLECHOICE;
            ShowForm();
        }

        private void 判断ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            examType = QuestionHistory.EXAM_TYPE_UNDO;
            problemKind = QuestionHistory.TYPE_JUDGE;
            ShowForm();
        }

        private void 版本信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutMe from = new AboutMe();
            from.Show();
        }

        private void 单选ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            examType = QuestionHistory.EXAM_TYPE_WRONG;
            problemKind = QuestionHistory.TYPE_CHOICE;
            ShowForm();
        }

        private void 多选ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            examType = QuestionHistory.EXAM_TYPE_WRONG;
            problemKind = QuestionHistory.TYPE_MULTIPLECHOICE;
            ShowForm();
        }

        private void 判断ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            examType = QuestionHistory.EXAM_TYPE_WRONG;
            problemKind = QuestionHistory.TYPE_JUDGE;
            ShowForm();
        }

        private void 单选ToolStripMenuItem2_Click(object sender, EventArgs e)
        {

            examType = QuestionHistory.EXAM_TYPE_REVIEW;
            problemKind = QuestionHistory.TYPE_CHOICE;
            ShowForm();
        }

        private void 多选ToolStripMenuItem2_Click(object sender, EventArgs e)
        {

            examType = QuestionHistory.EXAM_TYPE_REVIEW;
            problemKind = QuestionHistory.TYPE_MULTIPLECHOICE;
            ShowForm();
        }

        private void 判断ToolStripMenuItem2_Click(object sender, EventArgs e)
        {

            examType = QuestionHistory.EXAM_TYPE_REVIEW;
            problemKind = QuestionHistory.TYPE_JUDGE;
            ShowForm();
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
