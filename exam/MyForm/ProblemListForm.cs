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

namespace exam.MyForm
{
    public partial class ProblemListForm : Form
    {
        private int problemKind = QuestionHistory.TYPE_CHOICE;
        private int typeId = 0;
        
        private string[] problemKindList;
        private List<ProblemType> typeList;

        private ProblemType selectType;

        private List<object> problemList = new List<object>();

        public ProblemListForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowProblemData();
        }

        private void ShowProblemData()
        {
            long typeId = -1;
            if (selectType != null)
            {
                typeId = selectType.id;
            }
            problemList.Clear();

            switch (problemKind)
            {
                case QuestionHistory.TYPE_CHOICE:
                    problemList.AddRange(Choice.LoadAllChoice(typeId));
                    break;
                case QuestionHistory.TYPE_MULTIPLECHOICE:
                    problemList.AddRange(MultipleChoice.LoadAllMultipleChoice(typeId));
                    break;
                case QuestionHistory.TYPE_JUDGE:
                    problemList.AddRange(Judge.LoadAllMultipleChoice(typeId));
                    break;
            }

            UpdateUI();
        }

        private void InitData()
        {
            problemKindList = new string[]
            {
                "单选","多选","判断"
            };
            typeList = ProblemType.GetProblemTypeList();

            problemtype.Items.Clear();
            problemtype.Items.AddRange(problemKindList);
            problemtype.SelectedIndex = 0;

            type.Items.Clear();
            type.Items.Add("全部");
            for (int i = 0; i < typeList.Count;i++)
            {
                type.Items.Add(typeList[i].name);
            }
            type.SelectedIndex = 0;


            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 70);
            problemListView.SmallImageList = imgList;
        }

        private void UpdateUI()
        {
            if (problemList.Count == 0)
            {
                return;
            }

            switch (problemKind)
            {
                case QuestionHistory.TYPE_CHOICE:
                    ShowChoice();
                    break;
                case QuestionHistory.TYPE_MULTIPLECHOICE:
                    ShowMultipleChoice();
                    break;
                case QuestionHistory.TYPE_JUDGE:
                    ShowJudge();
                    break;
            }


        }

        private void ShowChoice()
        {
            problemListView.Columns.Clear();
            problemListView.Items.Clear();
            int width = problemListView.Width;

            this.problemListView.BeginUpdate();
            problemListView.Columns.Add("题目id", width * 5 / 100);
            problemListView.Columns.Add("题目内容", width * 24 / 100);
            problemListView.Columns.Add("答案A", width * 14 / 100);
            problemListView.Columns.Add("答案B", width * 14 / 100);
            problemListView.Columns.Add("答案C", width * 14 / 100);
            problemListView.Columns.Add("答案D", width * 14 / 100);
            problemListView.Columns.Add("正确答案", width * 5 / 100);
            problemListView.Columns.Add("是否做过", width * 5 / 100);
            problemListView.Columns.Add("问题类型", width * 5 / 100);

            for (int i = 0; i < problemList.Count; i ++)
            {
                ListViewItem item = new ListViewItem();

                Choice choice = (Choice)problemList[i];

                item.Text = choice.id.ToString();
                item.SubItems.Add(choice.content);
                item.SubItems.Add(choice.aska);
                item.SubItems.Add(choice.askb);
                item.SubItems.Add(choice.askc);
                item.SubItems.Add(choice.askd);
                item.SubItems.Add(choice.ans);
                item.SubItems.Add(choice.isDone == 0 ? "否" : "是");
                item.SubItems.Add(choice.typeName);

                problemListView.Items.Add(item);
            }
            this.problemListView.EndUpdate();
        }

        private void ShowMultipleChoice()
        {

        }

        private void ShowJudge()
        {

        }

        private void ProblemListForm_Load(object sender, EventArgs e)
        {
            InitData();
        }

        private void problemtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(((ComboBox)sender).SelectedIndex)
            {
                case 0:
                    problemKind = QuestionHistory.TYPE_CHOICE;
                    break;
                case 1:
                    problemKind = QuestionHistory.TYPE_MULTIPLECHOICE;
                    break;
                case 2:
                    problemKind = QuestionHistory.TYPE_JUDGE;
                    break;
            }
        }

        private void type_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = ((ComboBox)sender).SelectedIndex;
            if (index == 0)
            {
                selectType = null;
            } else
            {
                selectType = typeList[index-1];
            }
        }
    }
}
