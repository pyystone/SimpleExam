using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam.DB
{
    class ProblemType
    {
        public static string TABLE_NAME = "problem_type";

        public long id;
        public string name;

        public static List<ProblemType> GetProblemTypeList()
        {
            List<ProblemType> list = new List<ProblemType>();

            string sql = String.Format("select * from {0}", TABLE_NAME);
            DataSet ds = SQLiteHelper.Query(sql);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ProblemType item = new ProblemType
                {
                    id = (long)ds.Tables[0].Rows[i].ItemArray[0],
                    name = (string)ds.Tables[0].Rows[i].ItemArray[1]
                };
                list.Add(item);
            }

            return list;
        }

    }
}
