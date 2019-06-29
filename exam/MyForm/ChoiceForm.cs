using System;
using exam.DB;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using exam.Tools;

namespace exam.MyForm
{
    public partial class ChoiceForm : Form
    {
        // 0为正常训练，1为错题模式。
        private long examType = 0;

        // 题目游标
        private int index = 0;

        // 当前题目的实体
        private Choice choice;

        private List<Choice> list = new List<Choice>();

        public ChoiceForm()
        {
            InitializeComponent();
        }

        public void SetExamType(long type)
        {
            examType = type;
        } 

        private void UpdateUI()
        {
            switch (examType)
            {
                case QuestionHistory.EXAM_TYPE_UNDO:
                    this.Text = "选择题训练 - 训练模式（全部是没做过的题目及部分做错的题目）";
                    break;
                case QuestionHistory.EXAM_TYPE_WRONG:
                    this.Text = "选择题训练 - 错题模式（全部是做错的题目）";
                    break;
                case QuestionHistory.EXAM_TYPE_REVIEW:
                    this.Text = "选择题训练 - 复习模式（全部是做过的题）";
                    break;
            }

            if (list.Count == 0)
            {
                return;
            }
            
            content.Text = list[index].content;

            aska.Text = list[index].aska;
            aska.Checked = false;

            askb.Text = list[index].askb;
            askb.Checked = false;

            askc.Text = list[index].askc;
            askc.Checked = false;

            askd.Text = list[index].askd;
            askd.Checked = false;

            choice = list[index];

        }

        private void UpdateData()
        {
            if (examType == QuestionHistory.EXAM_TYPE_UNDO)
            {
                list.AddRange(Choice.LoadUndoChoice(100));
                list.AddRange(QuestionHistory.LoadChoice(QuestionHistory.EXAM_TYPE_WRONG,10));
            }
            else if (examType == QuestionHistory.EXAM_TYPE_WRONG)
            {
                list.AddRange(QuestionHistory.LoadChoice(QuestionHistory.EXAM_TYPE_WRONG,100));
            }
            else if (examType == QuestionHistory.EXAM_TYPE_REVIEW)
            {
                list.AddRange(QuestionHistory.LoadChoice(QuestionHistory.EXAM_TYPE_REVIEW, 100));
            }
            list = Util.RandomSortList(list);
            index = 0;
        }
        

        private void ChoiceForm_Load(object sender, EventArgs e)
        {
            if (list.Count == 0)
            {
                UpdateData();
            }
            UpdateUI();
        }

        private string CheckAns()
        {
            string userAns = "";
            if (aska.Checked == true)
            {
                userAns = "A";
            }
            else if (askb.Checked == true)
            {
                userAns = "B";
            }
            else if (askc.Checked == true)
            {
                userAns = "C";
            }
            else if (askd.Checked == true)
            {
                userAns = "D";
            }

            if (choice.isDone == 0)
            {
                QuestionHistory.SaveProblemIsDone(choice.id, QuestionHistory.TYPE_CHOICE);
            }
            
            if (userAns.Equals(choice.ans))
            {
                QuestionHistory.UpdateHistory(list[index], QuestionHistory.RESULT_RIGHT);
                return "";
            }
            else
            {
                QuestionHistory.UpdateHistory(list[index], QuestionHistory.RESULT_WRONG);
                return "你的选择是" + userAns + "\n\n" + "正确答案为" + choice.ans;
            }
        }

        private void ShowWrongMessage(string msg)
        {
            errorLabel.Text = msg;
            button1.Text = "点击以后进入下一题";
        }

        private void ShowNextQuestion()
        {
            index++;
            if (index >= list.Count)
            {
                UpdateData();
            }
            UpdateUI();
            button1.Text = "提交答案";
        }

        // 0 表示提交答案模式
        // 1 表示审阅正确答案模式
        private long button_state = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (list.Count == 0)
            {
                MessageBox.Show("没有题目了，请添加题目！");
                return;
            }

            if (button_state == 1)
            {
                errorLabel.Text = "";
                ShowNextQuestion();
                button_state = 0;
                return;
            }

            string msg = CheckAns();
            if (!msg.Equals(""))
            {
                ShowWrongMessage(msg);
                button_state = 1;
                return;
            }

            errorLabel.Text = "回答正确，自动给您切换下一题";
            ShowNextQuestion();
        }
    }
}
