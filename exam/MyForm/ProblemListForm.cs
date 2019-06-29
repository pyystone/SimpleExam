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

        private int problem_type = QuestionHistory.TYPE_CHOICE;
        private int type_id = 0;

        public ProblemListForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ProblemListForm_Load(object sender, EventArgs e)
        {
            problemtype.Items.Add("单选");
            problemtype.Items.Add("多选");
            problemtype.Items.Add("判断");

            
        }

        private void problemtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(((ComboBox)sender).SelectedIndex)
            {
                case 0:
                    problem_type = QuestionHistory.TYPE_CHOICE;
                    break;
                case 1:
                    problem_type = QuestionHistory.TYPE_MULTIPLECHOICE;
                    break;
                case 2:
                    problem_type = QuestionHistory.TYPE_JUDGE;
                    break;
            }
        }

        private void type_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
