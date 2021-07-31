using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SakuraDiff
{
    class Program
    {
        static void Main(string[] args)
        {

            //デバッグ用変数
            string debug_log = "";


            //起動される時は比較されるファイル2つが引数として指定されるはずなので、引数が2つ以外の場合はエラーとして終了する。
            if(args.Length!=2)
            {
                debug_log = "引数が2つ以外でした";
                MessageBox.Show(debug_log);
                Environment.Exit(0);
            }


            try
            {
                
                //変数宣言
                string DiffProgram = "";    //diff.iniの「DiffProgram」用
                int WaitTime = 0;   //diff.iniの「WaitTime」用
                int WaitProcess = 0;   //diff.iniの「WaitProcess」用
                int ExitWaitTime = 1000;    //diff.iniの「ExitWaitTime」用
                string FixArg = ""; //diff.iniの「FixArg」用


                //サクラエディタから渡される引数から比較対象ファイルのパスを取得
                string diff_file1 = args[0];
                string diff_file2 = args[1];


                //デバッグ用変数に引数の値を追加
                debug_log += "diff_file1：" + diff_file1 + "\r\n";
                debug_log += "diff_file2：" + diff_file2 + "\r\n";


                //diff.exeのディレクトリパスを取得
                debug_log += "diff.exeのディレクトリパスを取得" + "\r\n";
                string CurrentPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);


                //diff.exeと同じディレクトリにあるdiff.iniを読み込み
                debug_log += "diff.exeと同じディレクトリにあるdiff.iniを読み込み" + "\r\n";
                System.IO.StreamReader sr = new System.IO.StreamReader(CurrentPath + "\\diff.ini", System.Text.Encoding.GetEncoding("UTF-8"));


                //diff.iniから設定内容を読みだす
                debug_log += "diff.iniから設定内容を読みだす" + "\r\n";
                while (sr.EndOfStream == false)
                {
                    string line = sr.ReadLine();

                    //DiffProgram
                    if (line.IndexOf("DiffProgram=") == 0)
                    {
                        debug_log += "diff.iniから設定内容を読みだす(DiffProgram)" + "\r\n";
                        DiffProgram = line.Replace("DiffProgram=", "");
                    }

                    //WaitTime
                    if (line.IndexOf("WaitTime=") == 0)
                    {
                        debug_log += "diff.iniから設定内容を読みだす(WaitTime)" + "\r\n";
                        WaitTime = int.Parse(line.Replace("WaitTime=", ""));
                    }

                    //WaitProcess
                    if (line.IndexOf("WaitProcess=") == 0)
                    {
                        debug_log += "diff.iniから設定内容を読みだす(WaitProcess)" + "\r\n";
                        WaitProcess = int.Parse(line.Replace("WaitProcess=", ""));
                    }

                    //ExitWaitTime
                    if (line.IndexOf("ExitWaitTime=") == 0)
                    {
                        debug_log += "diff.iniから設定内容を読みだす(ExitWaitTime)" + "\r\n";
                        ExitWaitTime = int.Parse(line.Replace("ExitWaitTime=", ""));
                    }

                    //FixArg
                    if (line.IndexOf("FixArg=") == 0)
                    {
                        debug_log += "diff.iniから設定内容を読みだす(FixArg)" + "\r\n";
                        FixArg = line.Replace("FixArg=", "");
                    }
                }


                //デバッグ用変数にdiff.iniから読みだした値を追加
                debug_log += "DiffProgram：" + DiffProgram + "\r\n";
                debug_log += "WaitTime：" + WaitTime + "\r\n";
                debug_log += "WaitProcess：" + WaitProcess + "\r\n";
                debug_log += "ExitWaitTime：" + ExitWaitTime + "\r\n";
                debug_log += "FixArg：" + FixArg + "\r\n";


                //WaitTimeで指定した分だけSleep(待ち)
                debug_log += "WaitTimeで指定した分だけSleep(待ち)" + "\r\n";
                System.Threading.Thread.Sleep(WaitTime);


                //DiffProgramに比較対象ファイルとFixArgで指定した引数を渡しつつ起動
                debug_log += "DiffProgramに比較対象ファイルとFixArgで指定した引数を渡しつつ起動" + "\r\n";
                System.Diagnostics.Process p = System.Diagnostics.Process.Start(DiffProgram, "" + diff_file1 + " " + diff_file2 + " " + FixArg);

                //WaitProcessが1の場合、ユーザー指定のDIFFソフトが終了するまで待つ
                if (WaitProcess == 1)
                {
                    p.WaitForExit();
                }


                //ExitWaitTimeで指定した分だけSleep(待ち)
                debug_log += "ExitWaitTimeで指定した分だけSleep(待ち)" + "\r\n";
                System.Threading.Thread.Sleep(ExitWaitTime);

                //MessageBox.Show("owata");

            }
            catch(Exception e)
            {
                //例外のエラーが発生した場合はMessageBoxを表示
                MessageBox.Show("エラー(例外)が発生しました\r\n\r\n" + e.Message + "\r\n\r\n" + "---以下デバッグログ---" + "\r\n\r\n" + debug_log　+ "↑恐らく上記の処理でエラー発生");
            }
        }
    }
}
