using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam.DB
{
    class DBManager
    {
        private static readonly int VERISON = 1;

        
        public static void CreateDB()
        {
            if (!System.IO.File.Exists(SQLiteHelper.DB_NAME))
            {
                SQLiteHelper.CreateDB();
            }
        }
        public static void InitDB()
        {
            int i = CheckVerison();

            if (i == VERISON)
            {
                return;
            }

            for (; i <= VERISON; i ++)
            {
                UpdateDB(i);
            }
            SQLiteHelper.ExecuteSql("");
        }

        private static int CheckVerison()
        {
            int version = 1;
            version = (int)SQLiteHelper.GetSingle("select * from DB_VERSION");
            return version;
        }

        private static void UpdateDB(int version)
        {
            switch(version)
            {
                case 1:
                    ArrayList list = new ArrayList
                    {
                        "create TABLE persons(Id int, account varchar(255), pwd(255))",
                        "create TABLE choice(Id int, content varchar(255), aska varchar(255),askb varchar(255), askc varchar(255), askd varchar(255), ans varchar(255)，typeid int)",
                        "create TABLE error(userid int,problem_id,lasttime int,number int , ask_right int, error_times int , right_times int)"
                    };

                    SQLiteHelper.ExecuteSqlTran(list);
                    break;

                case 2:
                    list = new ArrayList
                    {
                        "create TABLE question_type(id int, name varchar(255))"
                    };

                    SQLiteHelper.ExecuteSqlTran(list);
                    break;
            }
        }
    }
}
