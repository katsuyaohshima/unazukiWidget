using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnazukiWidget
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string name = "";
            string imgPath = "";
            //コマンドライン引数を配列で取得する
            string[] cmds = System.Environment.GetCommandLineArgs();
            //コマンドライン引数を列挙する
            int i = 0;
            foreach (string cmd in cmds)
            {
                if (i == 1) { name = cmd; }
                if (i == 2) { imgPath = cmd; }
                i++;
            }


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new widget(name,imgPath));
        }
    }
}
