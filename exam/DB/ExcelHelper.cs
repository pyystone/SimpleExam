using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam.DB
{
    class ExcelHelper
    {
        public static DataSet ExcelToDS(string Path)
        {
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Path + ";" + "Extended Properties=Excel 8.0;";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            string strExcel = "";
            OleDbDataAdapter myCommand = null;
            DataSet ds = null;
            strExcel = "select * from [sheet1$]";
            myCommand = new OleDbDataAdapter(strExcel, strConn);
            ds = new DataSet();
            myCommand.Fill(ds, "table1");
            return ds;
        }

        public static void ImportChoiceQuestion(string filePath)
        {
            DataSet ds = ExcelToDS(filePath);
            List<Choice> choiceList = new List<Choice>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i ++)
            {
                Choice item = new Choice
                {
                    content = ds.Tables[0].Rows[i].ItemArray[0].ToString(),
                    aska = ds.Tables[0].Rows[i].ItemArray[1].ToString(),
                    askb = ds.Tables[0].Rows[i].ItemArray[2].ToString(),
                    askc = ds.Tables[0].Rows[i].ItemArray[3].ToString(),
                    askd = ds.Tables[0].Rows[i].ItemArray[4].ToString(),
                    ans = ds.Tables[0].Rows[i].ItemArray[5].ToString(),
                    typeName = ds.Tables[0].Rows[i].ItemArray[6].ToString()
                };
                choiceList.Add(item);
            }
            DBManager.ImportChoice(choiceList);
        }

        public static void ImportMultipleChoiceQuestion(string filePath)
        {
            DataSet ds = ExcelToDS(filePath);
            List<MultipleChoice> choiceList = new List<MultipleChoice>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                MultipleChoice item = new MultipleChoice
                {
                    content = ds.Tables[0].Rows[i].ItemArray[0].ToString(),
                    aska = ds.Tables[0].Rows[i].ItemArray[1].ToString(),
                    askb = ds.Tables[0].Rows[i].ItemArray[2].ToString(),
                    askc = ds.Tables[0].Rows[i].ItemArray[3].ToString(),
                    askd = ds.Tables[0].Rows[i].ItemArray[4].ToString(),
                    ans = ds.Tables[0].Rows[i].ItemArray[5].ToString(),
                    typeName = ds.Tables[0].Rows[i].ItemArray[6].ToString()
                };
                choiceList.Add(item);
            }
            DBManager.ImportMultipleChoice(choiceList);
        }

        public static void ImportJudgeQuestion(string filePath)
        {
            DataSet ds = ExcelToDS(filePath);
            List<Judge> choiceList = new List<Judge>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Judge item = new Judge
                {
                    content = ds.Tables[0].Rows[i].ItemArray[0].ToString(),
                    ans = TranslateJudgeAns((string)ds.Tables[0].Rows[i].ItemArray[1]),
                    typeName = ds.Tables[0].Rows[i].ItemArray[2].ToString()
                };
                choiceList.Add(item);
            }
            DBManager.ImportJudge(choiceList);
        }

        private static long TranslateJudgeAns(string ans)
        {
            if (ans.Equals("对"))
            {
                return Judge.RIGHT;
            }
            else if (ans.Equals("错"))
            {
                return Judge.WRONG;
            }
            return Judge.WRONG;
        }
    }
}
