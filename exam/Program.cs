﻿using exam.DB;
using exam.MyForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exam
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            InitAPP();

            Application.Run(new MainForm());
            
        }

        static void InitAPP()
        {
            InitDB();
        }

        static void InitDB()
        {
            DBManager.InitDB();
        }
    }
}
