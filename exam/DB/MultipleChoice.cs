using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam.DB
{
    class MultipleChoice
    {
        public static string TABLE_NAME = "multiple_choice";
        public long id;
        public String content;
        public String aska;
        public String askb;
        public String askc;
        public String askd;
        public String ans;
        public long typeId;
        public long isDone;
        public String typeName;

        public static List<MultipleChoice> LoadUndoMultipleChoice(long count)
        {
            List<MultipleChoice> list = new List<MultipleChoice>();
            string sql = String.Format("select * from {0} as a left join {1} as b on a.typeid = b.id where isdone = 0 limit {2}", TABLE_NAME, ProblemType.TABLE_NAME, count);
            DataSet ds = SQLiteHelper.Query(sql);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                MultipleChoice item = new MultipleChoice
                {
                    id = (long)ds.Tables[0].Rows[i].ItemArray[0],
                    content = (string)ds.Tables[0].Rows[i].ItemArray[1],
                    aska = (string)ds.Tables[0].Rows[i].ItemArray[2],
                    askb = (string)ds.Tables[0].Rows[i].ItemArray[3],
                    askc = (string)ds.Tables[0].Rows[i].ItemArray[4],
                    askd = (string)ds.Tables[0].Rows[i].ItemArray[5],
                    ans = (string)ds.Tables[0].Rows[i].ItemArray[6],
                    typeId = (long)ds.Tables[0].Rows[i].ItemArray[7],
                    isDone = (long)ds.Tables[0].Rows[i].ItemArray[8],
                    typeName = (string)ds.Tables[0].Rows[i].ItemArray[10]
                };
                list.Add(item);
            }
            return list;
        }
    }
}
