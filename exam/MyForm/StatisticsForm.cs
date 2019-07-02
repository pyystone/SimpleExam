using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using exam.DB;

namespace exam.MyForm
{
    public partial class StatisticsForm : Form
    {
        public static readonly List<string> menus = new List<string>
        {
            "题目类型","做题数","做错题数"
        };

        public static readonly List<int> widths = new List<int>
        {
            50,25,25
        };
        public static readonly List<HorizontalAlignment> textAligns = new List<HorizontalAlignment>
        {
            HorizontalAlignment.Left,HorizontalAlignment.Center,HorizontalAlignment.Center
        };


        public StatisticsForm()
        {
            InitializeComponent();
        }

        private void StatisticsFormcs_Load(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void UpdateUI()
        {

            ImageList imgList = new ImageList
            {
                ImageSize = new Size(1, 70)
            };
            nowListView.SmallImageList = imgList;
            historyListView.SmallImageList = imgList;

            UpdateNowList();
            UpdateHistoryList();
        }

        private void UpdateNowList()
        {
            int choiceCount = MyApp.choiceCount;
            int multipleChoiceCount = MyApp.multipleChoiceCount;
            int judgeCount = MyApp.judgeCount;
            int sum = choiceCount + multipleChoiceCount + judgeCount;

            int choiceWrongCount = MyApp.choiceWrongCount;
            int multipleChoiceWrongCount = MyApp.multipleChoiceWrongCount;
            int judgeWrongCount = MyApp.judgeWrongCount;
            int wrongSum = choiceWrongCount + multipleChoiceWrongCount + judgeWrongCount;
            
            this.nowListView.BeginUpdate();
            int width = nowListView.Width;
            for (int i = 0; i < menus.Count; i++)
            {
                nowListView.Columns.Add(menus[i], width * widths[i] / 100, textAligns[i]);
            }
            ListViewItem item = new ListViewItem
            {
                Text = "总做题数"
            };
            item.SubItems.Add(sum.ToString());
            item.SubItems.Add(wrongSum.ToString());
            nowListView.Items.Add(item);

            item = new ListViewItem
            {
                Text = "单选题"
            };
            item.SubItems.Add(choiceCount.ToString());
            item.SubItems.Add(choiceWrongCount.ToString());
            nowListView.Items.Add(item);

            item = new ListViewItem
            {
                Text = "多选题"
            };
            item.SubItems.Add(multipleChoiceCount.ToString());
            item.SubItems.Add(multipleChoiceWrongCount.ToString());
            nowListView.Items.Add(item);

            item = new ListViewItem
            {
                Text = "判断题"
            };
            item.SubItems.Add(judgeCount.ToString());
            item.SubItems.Add(judgeWrongCount.ToString());
            nowListView.Items.Add(item);

            this.nowListView.EndUpdate();

        }

        private void UpdateHistoryList()
        {
            long choiceCount = QuestionHistory.GetHisotryCount(QuestionHistory.TYPE_CHOICE);
            long multipleChoiceCount = QuestionHistory.GetHisotryCount(QuestionHistory.TYPE_MULTIPLECHOICE);
            long judgeCount = QuestionHistory.GetHisotryCount(QuestionHistory.TYPE_JUDGE);
            long sum = choiceCount + multipleChoiceCount + judgeCount;

            long choiceWrongCount = QuestionHistory.GetWrongHisotryCount(QuestionHistory.TYPE_CHOICE);
            long multipleChoiceWrongCount = QuestionHistory.GetWrongHisotryCount(QuestionHistory.TYPE_MULTIPLECHOICE);
            long judgeWrongCount = QuestionHistory.GetWrongHisotryCount(QuestionHistory.TYPE_JUDGE);
            long wrongSum = choiceWrongCount + multipleChoiceWrongCount + judgeWrongCount;


            this.historyListView.BeginUpdate();
            int width = historyListView.Width;
            for (int i = 0; i < menus.Count; i++)
            {
                historyListView.Columns.Add(menus[i], width * widths[i] / 100, textAligns[i]);
            }

            ListViewItem item = new ListViewItem
            {
                Text = "总做题数"
            };
            item.SubItems.Add(sum.ToString());
            item.SubItems.Add(wrongSum.ToString());
            historyListView.Items.Add(item);

            ListViewItem item2 = new ListViewItem
            {
                Text = "单选题"
            };
            item2.SubItems.Add(choiceCount.ToString());
            item2.SubItems.Add(choiceWrongCount.ToString());
            historyListView.Items.Add(item2);

            ListViewItem item3 = new ListViewItem
            {
                Text = "多选题"
            };
            item3.SubItems.Add(multipleChoiceCount.ToString());
            item3.SubItems.Add(multipleChoiceWrongCount.ToString());
            historyListView.Items.Add(item3);

            ListViewItem item4 = new ListViewItem
            {
                Text = "判断题"
            };
            item4.SubItems.Add(judgeCount.ToString());
            item4.SubItems.Add(judgeWrongCount.ToString());
            historyListView.Items.Add(item4);

            this.historyListView.EndUpdate();
        }
        
    }
}
