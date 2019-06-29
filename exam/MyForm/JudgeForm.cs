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
    public partial class JudgeForm : Form
    {

        /// <summary>
        /// 0为正常训练， 没做过的题目
        /// 1为错题模式， 做错过的题目，排序为 错误次数/做题数 最高的
        /// 2为综合复习。 做过的题目，做过次数最少的。
        /// 
        /// </summary>
        private long examType = 0;

        // 题目游标
        private int index = 0;

        // 当前题目的实体
        private Judge judge;

        private List<Judge> list = new List<Judge>();

        public JudgeForm()
        {
            InitializeComponent();
        }

        public void SetExamType(long type)
        {
            examType = type;
        }

        private void UpdateUI()
        {
            if (list.Count == 0)
            {
                return;
            }

            judge = list[index];

            content.Text = judge.content;

            right.Checked = false;
            wrong.Checked = false;

        }

        private void UpdateData()
        {
            if (examType == QuestionHistory.EXAM_TYPE_UNDO)
            {
                list.AddRange(Judge.LoadUndoChoice(100));
                list.AddRange(QuestionHistory.LoadJudge(QuestionHistory.EXAM_TYPE_WRONG, 10));
            }
            else if (examType == QuestionHistory.EXAM_TYPE_WRONG)
            {
                list.AddRange(QuestionHistory.LoadJudge(QuestionHistory.EXAM_TYPE_WRONG, 100));
            }
            else if (examType == QuestionHistory.EXAM_TYPE_REVIEW)
            {
                list.AddRange(QuestionHistory.LoadJudge(QuestionHistory.EXAM_TYPE_REVIEW, 100));
            }
            list = Util.RandomSortList(list);
            index = 0;
        }

        private string CheckAns()
        {
            int userAns = Judge.RIGHT;
            if (right.Checked == true)
            {
                userAns = Judge.RIGHT;
            }
            else if (wrong.Checked == true)
            {
                userAns = Judge.WRONG;
            }

            if (judge.isDone == 0)
            {
                QuestionHistory.SaveProblemIsDone(judge.id, QuestionHistory.TYPE_CHOICE);
            }

            if (userAns == judge.ans)
            {
                QuestionHistory.UpdateHistory(judge, QuestionHistory.RESULT_RIGHT);
                return "";
            }
            else
            {
                QuestionHistory.UpdateHistory(judge, QuestionHistory.RESULT_WRONG);
                return "你的选择是" + TranslateAns(userAns) + "\n\n" + "正确答案为" + TranslateAns(judge.ans);
            }
        }

        private string TranslateAns(long ans)
        {
            return ans == Judge.RIGHT ? "正确" : "错误";
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

        private void JudgeForm_Load(object sender, EventArgs e)
        {
            
            if (list.Count == 0)
            {
                UpdateData();
            }
            UpdateUI();
        }
    }
}
