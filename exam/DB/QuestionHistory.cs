using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exam.Tools;

namespace exam.DB
{
    class QuestionHistory
    {
        public const int USER_ID = 1;

        /// <summary>
        /// 单选题
        /// </summary>
        public const int TYPE_CHOICE = 0;
        /// <summary>
        /// 多选题
        /// </summary>
        public const int TYPE_MULTIPLECHOICE = 1;
        /// <summary>
        /// 判断题
        /// </summary>
        public const int TYPE_JUDGE = 2;
        /// <summary>
        /// 显示统计
        /// </summary>
        public const int TYPE_STATISTICS = 998;
        /// <summary>
        /// 显示题库
        /// </summary>
        public const int TYPE_PROBLEMLIST = 999;

        /// <summary>
        /// 题目答错
        /// </summary>
        public const int RESULT_WRONG = 0;
        /// <summary>
        /// 题目答对
        /// </summary>
        public const int RESULT_RIGHT = 1;

        /// <summary>
        /// 没做，新题
        /// </summary>
        public const int EXAM_TYPE_UNDO = 0;
        /// <summary>
        /// 做错
        /// </summary>
        public const int EXAM_TYPE_WRONG = 1;
        /// <summary>
        /// 复习
        /// </summary>
        public const int EXAM_TYPE_REVIEW = 2;


        public static string TABLE_NAME = "history";
        public long userId;
        public long problem_id;
        public long type; // 0 选择题，1多选题，2判断题
        public long lastTime; // 上次做题时间
        public long number; // 做题次数
        public long ask_right; // 上次是否正确， 0 正确，1 错误
        public long error_times; // 错误次数
        public long right_times; // 正确次数

        public static void UpdateHistory(Choice choice, int isRight)
        {
            UpdateHistory(TYPE_CHOICE, choice.id, USER_ID, isRight);
        }

        public static void UpdateHistory(MultipleChoice multipleChoice, int isRight)
        {
            UpdateHistory(TYPE_MULTIPLECHOICE, multipleChoice.id, USER_ID, isRight);
        }

        public static void UpdateHistory(Judge judge, int isRight)
        {
            UpdateHistory(TYPE_JUDGE, judge.id, USER_ID, isRight);
        }

        /// <summary>
        /// 更新做题记录
        /// </summary>
        /// <param name="type">题目的类型</param>
        /// <param name="id">题目的id</param>
        /// <param name="userid">用户id</param>
        /// <param name="isRight">答题是否正确</param>
        private static void UpdateHistory(int type, long id, long userid, int isRight)
        {

            DataSet ds = SQLiteHelper.Query(
                String.Format("select * from {0} where problem_id = {1} and userid = {2}", TABLE_NAME, id, USER_ID)
                );
            QuestionHistory history;
            string sql;
            if (ds.Tables[0].Rows.Count == 0)
            {
                history = new QuestionHistory
                {
                    userId = userid,
                    problem_id = id,
                    type = type,
                    lastTime = Util.GetTimeStamp(),
                    number = 1,
                    ask_right = isRight,
                    error_times = isRight == 0 ? 1 : 0,
                    right_times = isRight

                };

                sql = String.Format("insert into {0}" +
                    " (userid,problem_id,type,lasttime,number,ask_right,error_times,right_times)" +
                    " values({1},{2},{3},{4},{5},{6},{7},{8})",
                    TABLE_NAME, USER_ID, history.problem_id, history.type, history.lastTime, history.number, history.ask_right
                    , history.error_times, history.right_times);

            }
            else
            {
                history = new QuestionHistory
                {
                    userId = (long)ds.Tables[0].Rows[0].ItemArray[0],
                    problem_id = (long)ds.Tables[0].Rows[0].ItemArray[1],
                    type = type,
                    lastTime = Util.GetTimeStamp(),
                    number = (long)ds.Tables[0].Rows[0].ItemArray[3] + 1,
                    ask_right = isRight,
                    error_times = (long)ds.Tables[0].Rows[0].ItemArray[5] + (isRight == 0 ? 1 : 0),
                    right_times = (long)ds.Tables[0].Rows[0].ItemArray[6] + isRight
                };

                sql = String.Format("update {0} SET" +
                    " lasttime = {1},number = {2},ask_right = {3},error_times = {4},right_times = {5}" +
                    " where problem_id = {6} and userid = {7} and type = {8}",
                    TABLE_NAME, history.lastTime, history.number, history.ask_right,
                    history.error_times, history.right_times, history.problem_id, history.userId, history.type);
            }
            SQLiteHelper.ExecuteSql(sql);
        }

        /// <summary>
        /// 从数据库读取指定数量的单选题目
        /// </summary>
        /// <param name="examType">训练类型</param>
        /// <param name="count">数量</param>
        /// <returns>返回单选题列表</returns>
        public static List<Choice> LoadChoice(int examType,long count)
        {
            List<Choice> list = new List<Choice>();
            DataSet ds = null;
            if (examType == 1)
            {
                ds = LoadWrongHistory(TYPE_CHOICE, count);
            }
            else if (examType == 2){
                ds = LoadReviewHistory(TYPE_CHOICE, count);
            }
            if (ds == null)
            {
                return list;
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i ++)
            {
                list.Add(new Choice
                {
                    id = (long)ds.Tables[0].Rows[i].ItemArray[8],
                    content = (string)ds.Tables[0].Rows[i].ItemArray[9],
                    aska = (string)ds.Tables[0].Rows[i].ItemArray[10],
                    askb = (string)ds.Tables[0].Rows[i].ItemArray[11],
                    askc = (string)ds.Tables[0].Rows[i].ItemArray[12],
                    askd = (string)ds.Tables[0].Rows[i].ItemArray[13],
                    ans = (string)ds.Tables[0].Rows[i].ItemArray[14],
                    typeId = (long)ds.Tables[0].Rows[i].ItemArray[15],
                    typeName = (string)ds.Tables[0].Rows[i].ItemArray[18]
                });
            }
            return list;
        }

        /// <summary>
        /// 返回指定数量的多选题
        /// </summary>
        /// <param name="examType">训练类型</param>
        /// <param name="count">数量</param>
        /// <returns>多选题列表</returns>
        public static List<MultipleChoice> LoadMultipleChoice(int examType, long count)
        {
            List<MultipleChoice> list = new List<MultipleChoice>();
            DataSet ds = null;
            if (examType == 1)
            {
                ds = LoadWrongHistory(TYPE_MULTIPLECHOICE, count);
            }
            else if (examType == 2)
            {
                ds = LoadReviewHistory(TYPE_MULTIPLECHOICE, count);
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                list.Add(new MultipleChoice
                {
                    id = (long)ds.Tables[0].Rows[i].ItemArray[8],
                    content = (string)ds.Tables[0].Rows[i].ItemArray[9],
                    aska = (string)ds.Tables[0].Rows[i].ItemArray[10],
                    askb = (string)ds.Tables[0].Rows[i].ItemArray[11],
                    askc = (string)ds.Tables[0].Rows[i].ItemArray[12],
                    askd = (string)ds.Tables[0].Rows[i].ItemArray[13],
                    ans = (string)ds.Tables[0].Rows[i].ItemArray[14],
                    typeId = (long)ds.Tables[0].Rows[i].ItemArray[15],
                    typeName = (string)ds.Tables[0].Rows[i].ItemArray[18]

                });
            }

            return list;
        }

        /// <summary>
        /// 返回指定数量的判断题
        /// </summary>
        /// <param name="examType">训练类型</param>
        /// <param name="count">数量</param>
        /// <returns>判断题列表</returns>
        public static List<Judge> LoadJudge(int examType, long count)
        {
            List<Judge> list = new List<Judge>();
            DataSet ds = null;
            if (examType == 1)
            {
                ds = LoadWrongHistory(TYPE_JUDGE, count);
            }
            else if (examType == 2)
            {
                ds = LoadReviewHistory(TYPE_JUDGE, count);
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                list.Add(new Judge
                {
                    id = (long)ds.Tables[0].Rows[i].ItemArray[8],
                    content = (string)ds.Tables[0].Rows[i].ItemArray[9],
                    ans = (long)ds.Tables[0].Rows[i].ItemArray[10],
                    typeId = (long)ds.Tables[0].Rows[i].ItemArray[11],
                    typeName = (string)ds.Tables[0].Rows[i].ItemArray[14]
                });
            }

            return list;
        }

        /// <summary>
        /// 搜索指定类型的题目，错题/做题数最高的
        /// </summary>
        /// <param name="type">训练类型</param>
        /// <param name="count">数量</param>
        /// <returns></returns>
        public static DataSet LoadWrongHistory(int type , long count)
        {
            string table_name = GetTableName(type);
            string sql = String.Format("select * from {0} as a" +
                " left join {1} as b on a.problem_id = b.id" +
                " left join {2} as c on c.id = b.typeid" +
                " where type = {3} and error_times > 0 order by error_times*1.0/number desc limit {4}" 
                ,TABLE_NAME, table_name, ProblemType.TABLE_NAME, type, count);
            DataSet ds = SQLiteHelper.Query(sql);
            return ds;
        }

        /// <summary>
        /// 搜索指定类型的题目，做题次数最少的题目
        /// </summary>
        /// <param name="type"></param>
        /// <param name="count"></param>
        /// <returns></returns>        
        public static DataSet LoadReviewHistory(int type, long count)
        {
            string table_name = GetTableName(type);
            string sql = String.Format("select * from {0} as a" +
                " left join {1} as b on a.problem_id = b.id" +
                " left join {2} as c on c.id = b.typeid" +
                " where type = {3} order by number limit {4}"
                , TABLE_NAME, table_name, ProblemType.TABLE_NAME, type, count);
            DataSet ds = SQLiteHelper.Query(sql);
            return ds;
        }

        /// <summary>
        /// 保存题目是否已经做过
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        public static void SaveProblemIsDone(long id,int type)
        {
            string sql = "update " + GetTableName(type) + " set isdone = 1 where id =" + id;
            SQLiteHelper.ExecuteSql(sql);
        }

        /// <summary>
        /// 通过题目类型获得表名
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static string GetTableName(int type)
        {
            string table_name = "";
            switch(type)
            {
                case TYPE_CHOICE:
                    table_name = Choice.TABLE_NAME;
                    break;
                case TYPE_MULTIPLECHOICE:
                    table_name = MultipleChoice.TABLE_NAME;
                    break;
                case TYPE_JUDGE:
                    table_name = Judge.TABLE_NAME;
                    break;
            }
            return table_name;
        }
        
        /// <summary>
        /// 获得做题数
        /// </summary>
        /// <param name="type">题目类型，-1 表示所有</param>
        /// <returns></returns>
        public static long GetHisotryCount(int type)
        {
            string sql = String.Format("select count(number) from {0}", TABLE_NAME);
            if (type != -1)
            {
                sql += String.Format(" where type = {0}", type);
            }
            long count = (long)SQLiteHelper.GetSingle(sql);
            return count;
        }

        /// <summary>
        /// 获得做题数
        /// </summary>
        /// <param name="type">题目类型，-1 表示所有</param>
        /// <returns></returns>
        public static long GetWrongHisotryCount(int type)
        {
            string sql = String.Format("select count(error_times) from {0}", TABLE_NAME);
            if (type != -1)
            {
                sql += String.Format(" where type = {0}", type);
            }
            long count = (long)SQLiteHelper.GetSingle(sql);
            return count;
        }
    }
}
