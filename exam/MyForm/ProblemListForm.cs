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
        
        private static readonly string[] problemKindList = new string[]
        {
            "单选","多选","判断"
        };

        private List<ProblemType> typeList;

        private ProblemType selectType;

        private List<object> problemList = new List<object>();
        
        private static readonly List<string> choiceColumns = new List<string>
        {
            "题目id","题目内容","答案A","答案B","答案C"
            ,"答案D","正确答案","是否做过","问题类型"
        };

        private static readonly List<string> multipleChoiceColumns = new List<string>
        {
            "题目id","题目内容","答案A","答案B","答案C"
            ,"答案D","正确答案","是否做过","问题类型"
        };

        private static readonly List<string> judgeColumns = new List<string>
        {
            "题目id","题目内容","正确答案","是否做过","问题类型",
        };

        private static readonly List<int> choiceColumnsWidth = new List<int>
        {
            5,22,14,14,14
            ,14,5,5,5
        };


        private static readonly List<int> multipleChoiceColumnsWidth = new List<int>
        {
            5,22,14,14,14
            ,14,5,5,5
        };

        
        private static readonly List<int> judgeColumnsWidth = new List<int>
        {
            10,45,10,10,10
        };

        private static readonly List<HorizontalAlignment> choiceColumnsTextAligns = new List<HorizontalAlignment>
        {
            HorizontalAlignment.Left
            ,HorizontalAlignment.Left
            ,HorizontalAlignment.Left
            ,HorizontalAlignment.Left
            ,HorizontalAlignment.Left
            ,HorizontalAlignment.Left
            ,HorizontalAlignment.Center
            , HorizontalAlignment.Center
            , HorizontalAlignment.Center
        };

        private static readonly List<HorizontalAlignment> multipleChoiceColumnsTextAligns = new List<HorizontalAlignment>
        {
            HorizontalAlignment.Left
            ,HorizontalAlignment.Left
            ,HorizontalAlignment.Left
            ,HorizontalAlignment.Left
            ,HorizontalAlignment.Left
            ,HorizontalAlignment.Left
            ,HorizontalAlignment.Center
            , HorizontalAlignment.Center
            , HorizontalAlignment.Center
        };

        private static readonly List<HorizontalAlignment> judgeColumnsTextAligns = new List<HorizontalAlignment>
        {
            HorizontalAlignment.Left
            ,HorizontalAlignment.Left
            ,HorizontalAlignment.Center
            , HorizontalAlignment.Center
            , HorizontalAlignment.Center
        };

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


            ImageList imgList = new ImageList
            {
                ImageSize = new Size(1, 70)
            };
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

        private void InitProblemListViewColumns(List<string> columns , List<int> widths , List<HorizontalAlignment> textAligns)
        {
            problemListView.Columns.Clear();
            int width = problemListView.Width;
            for (int i = 0; i < columns.Count; i ++)
            {
                problemListView.Columns.Add(columns[i], width * widths[i] / 100, textAligns[i]);
            }
        }

        private void ShowChoice()
        {

            this.problemListView.BeginUpdate();
            InitProblemListViewColumns(choiceColumns,choiceColumnsWidth,choiceColumnsTextAligns);

            problemListView.Items.Clear();
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
            
            this.problemListView.BeginUpdate();
            InitProblemListViewColumns(multipleChoiceColumns, multipleChoiceColumnsWidth, multipleChoiceColumnsTextAligns);

            problemListView.Items.Clear();
            for (int i = 0; i < problemList.Count; i++)
            {
                ListViewItem item = new ListViewItem();

                MultipleChoice choice = (MultipleChoice)problemList[i];

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

        private void ShowJudge()
        {

            this.problemListView.BeginUpdate();
            InitProblemListViewColumns(judgeColumns, judgeColumnsWidth, judgeColumnsTextAligns);

            problemListView.Items.Clear();
            for (int i = 0; i < problemList.Count; i++)
            {
                ListViewItem item = new ListViewItem();

                Judge judge = (Judge)problemList[i];

                item.Text = judge.id.ToString();
                item.SubItems.Add(judge.content);
                item.SubItems.Add(judge.ans == Judge.RIGHT ? "正确" : "错误");
                item.SubItems.Add(judge.isDone == 0 ? "否" : "是");
                item.SubItems.Add(judge.typeName);

                problemListView.Items.Add(item);
            }
            this.problemListView.EndUpdate();
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
            ShowProblemData();
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
            ShowProblemData();
        }

        private void problemListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListView listview = (ListView)sender;
            ListViewItem lstrow = listview.GetItemAt(e.X, e.Y);
            System.Windows.Forms.ListViewItem.ListViewSubItem lstcol = lstrow.GetSubItemAt(e.X, e.Y);
            string strText = lstcol.Text;
            try
            {
                Clipboard.SetDataObject(strText);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
