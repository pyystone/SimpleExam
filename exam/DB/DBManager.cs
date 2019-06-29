using System;
using exam.DB;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam.DB
{
    class DBManager
    {
        private static readonly long VERISON = 2;

       
        public static void InitDB()
        {
            if (!System.IO.File.Exists(SQLiteHelper.DB_NAME))
            {
                SQLiteHelper.CreateDB();
            }
            long i = CheckVerison();

            if (i == VERISON)
            {
                return;
            }

            for (; i <= VERISON; i ++)
            {
                UpdateDB(i);
            }
            SQLiteHelper.ExecuteSql("update DB_VERSION set version = " + VERISON);
        }

        private static long CheckVerison()
        {
            long version = 1;
            version = (long)SQLiteHelper.GetSingle("select * from DB_VERSION");
            return version;
        }

        private static void UpdateDB(long version)
        {
            switch(version)
            {
                case 1:
                    ArrayList list = new ArrayList
                    {
                        "create TABLE persons(Id INTEGER, account varchar(255), pwd varchar(255))",
                        "create TABLE "+ Choice.TABLE_NAME +"(Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, content varchar(255), aska varchar(255),askb varchar(255), askc varchar(255), askd varchar(255), ans varchar(255), typeid INTEGER,isdone INTEGER default 0)",
                        "create TABLE "+ QuestionHistory.TABLE_NAME +"(userid INTEGER,problem_id,lasttime INTEGER,number INTEGER , ask_right INTEGER, error_times INTEGER , right_times INTEGER, type INTEGER)"
                    };

                    SQLiteHelper.ExecuteSqlTran(list);
                    break;

                case 2:
                    list = new ArrayList
                    {
                        "create TABLE "+ ProblemType.TABLE_NAME +"(id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name varchar(255))"
                        ,"create TABLE "+ MultipleChoice.TABLE_NAME+"(Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, content varchar(255), aska varchar(255),askb varchar(255), askc varchar(255), askd varchar(255), ans varchar(255), typeid INTEGER,isdone INTEGER default 0)"
                        ,"create TABLE "+ Judge.TABLE_NAME +"(id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, content varchar(255),ans INTEGER,typeid INTEGER,isdone INTEGER default 0)"
                    };

                    SQLiteHelper.ExecuteSqlTran(list);
                    break;
            }
        }

        private static long GetProblemId(string typeName)
        {
            Object obj = SQLiteHelper.GetSingle("select * from "+ ProblemType.TABLE_NAME + " where name = '" + typeName + "'");
            if (obj != null)
            {
                return (long)obj;
            }
            SQLiteHelper.ExecuteSql("insert into "+ ProblemType.TABLE_NAME + "(name) values('" + typeName + "')");
            ;
            return (long)SQLiteHelper.GetSingle("select * from "+ ProblemType.TABLE_NAME + " where name = '" + typeName + "'");
        }

        public static void ImportChoice(List<Choice> choices)
        {
            ArrayList list = new ArrayList();
            choices.ForEach((it) =>
            {
                it.typeId = GetProblemId(it.typeName);
                string sql = "insert into "+Choice.TABLE_NAME+"(content,aska,askb,askc,askd,ans,typeid) values('" +
                it.content + "','" + it.aska + "','" + it.askb + "','" + it.askc + "','" + it.askd + "','" + it.ans + "','" + it.typeId +
                "')";

                list.Add(sql);
            });
            SQLiteHelper.ExecuteSqlTran(list);
        }

        public static void ImportMultipleChoice(List<MultipleChoice> choices)
        {
            ArrayList list = new ArrayList();
            choices.ForEach((it) =>
            {
                it.typeId = GetProblemId(it.typeName);
                string sql = "insert into "+ MultipleChoice.TABLE_NAME +"(content,aska,askb,askc,askd,ans,typeid) values('" +
                it.content + "','" + it.aska + "','" + it.askb + "','" + it.askc + "','" + it.askd + "','" + it.ans + "','" + it.typeId +
                "')";

                list.Add(sql);
            });
            SQLiteHelper.ExecuteSqlTran(list);
        }

        public static void ImportJudge(List<Judge> choices)
        {
            ArrayList list = new ArrayList();
            choices.ForEach((it) =>
            {
                it.typeId = GetProblemId(it.typeName);
                string sql = "insert into "+Judge.TABLE_NAME+"(content,ans,typeid) values('" +
                it.content + "','"+ it.ans + "','" + it.typeId +
                "')";

                list.Add(sql);
            });
            SQLiteHelper.ExecuteSqlTran(list);
        }
    }
}
