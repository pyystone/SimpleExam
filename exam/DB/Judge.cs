using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam.DB
{
    class Judge
    {
        public const int RIGHT = 1;
        public const int WRONG = 0;
        public static string TABLE_NAME = "judge";
        // 题目id
        public long id;

        // 问题内容
        public string content;

        // 答案 0 错误 1 正确
        public long ans;

        //题目类型id
        public long typeId;

        // 题目类型
        public string typeName;

        public long isDone;

        public static List<Judge> LoadUndoChoice(long count)
        {
            List<Judge> list = new List<Judge>();
            string sql = String.Format("select * from {0} as a left join {1} as b on a.typeid = b.id where isdone = 0 limit {2}", TABLE_NAME, ProblemType.TABLE_NAME, count);
            DataSet ds = SQLiteHelper.Query(sql);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Judge item = new Judge
                {
                    id = (long)ds.Tables[0].Rows[i].ItemArray[0],
                    content = (string)ds.Tables[0].Rows[i].ItemArray[1],
                    ans = (long)ds.Tables[0].Rows[i].ItemArray[2],
                    typeId = (long)ds.Tables[0].Rows[i].ItemArray[3],
                    isDone = (long)ds.Tables[0].Rows[i].ItemArray[4],
                    typeName = (string)ds.Tables[0].Rows[i].ItemArray[6]
                };
                list.Add(item);
            }
            return list;
        }
    }
}
