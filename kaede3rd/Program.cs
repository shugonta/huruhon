using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace kaede3rd
{
    static class Program
    {
        public static AppConfig config;
        private static string configFile = "Settings.xml";

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            string cfgFullPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), configFile);

            if (!System.IO.File.Exists(cfgFullPath))
            {
                AppConfig c = new AppConfig();
                c.ConnectList.Add(new AppConfig.Connection
                {
                    cfgname = "テスト部門",
                    host = "localhost",
                    port = "3306",
                    user = "username",
                    pass = "password",
                    dbname = "database_name",
                });

                c.configPath = cfgFullPath;
                c.SaveToFile();
                MessageBox.Show("コンフィグファイル (" + c.GetConfigFileName() + ") を作成しました。");
            }

            try
            {
                config = AppConfig.LoadFromFile(cfgFullPath);
            }
            catch (Exception e)
            {
                MessageBox.Show("コンフィグファイル (" + configFile + ") が正常に開けませんでした。\nファイルが間違っていないか確認するか、諦めて削除して起動しなおしてください。\n\n詳細:\n"
                    + e.Message + (e.InnerException != null ? ("\n" + e.InnerException.Message) : ""));
                System.Environment.Exit(-1);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
