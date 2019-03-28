using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Test;
using Utils;

namespace Test2 {
    class Program {
        // private string value;
        static void Main (string[] args) {

            // Program p = new Program ();
            // Displacement dis = new Displacement ();
            // dis.Ini ();
            // System.Console.Write ("请输入数值:");
            // p.value = Console.ReadLine ();
            // System.Console.WriteLine ("输入数值: " + p.value);
            // ulong i = (ulong) int.Parse (p.value);
            // System.Console.WriteLine ("输入数值ulong : " + i);
            // //i += 50;
            // ulong x = (ulong) 1 << ((int) i);
            // System.Console.WriteLine ("输入数值<< ulong : " + x);
            // dis.OPen (x);
            // //dis.OPen (int.Parse (p.value));

            /*
            ByteArray aa = new ByteArray (new byte[10]);
            ByteArray bb = new ByteArray (new byte[20]);

            ByteArray cc = aa + bb;
            byte[] xxoo = cc.GetBytes ();
            for (int i = 0; i < xxoo.Length; i++) {
                Console.WriteLine (xxoo[i].ToString ());
            }
            System.Console.WriteLine(xxoo.Length);
            Console.ReadLine ();
            */
            // System.Console.WriteLine(ProgramEnum.EC.ERROR_COMMON_SUCCESS.ToString());
            // System.Console.Write ("请输入数值:");
            // Regex reg = new Regex ("^[0-9]+$");
            // string value = Console.ReadLine ();
            // Match ma = reg.Match (value);
            // int inputCount = 0;
            // bool isFlage = !string.IsNullOrEmpty (value) || !ma.Success;
            // while (string.IsNullOrEmpty (value) || !ma.Success) {
            //     inputCount++;
            //     if (inputCount > 5)
            //         break;
            //     System.Console.Write ("请重新输入:");
            //     value = Console.ReadLine ();
            //     ma = reg.Match (value);
            //     if (!(string.IsNullOrEmpty (value)) && ma.Success) {
            //         isFlage = true;
            //         break;
            //     }
            // }
            // if (isFlage) {
            //     string result = GameUtils.ParseCnToInt ((int) Convert.ToInt64 (value));
            //     System.Console.WriteLine ("转换后: " + result);
            // } else {
            //     System.Console.WriteLine ("输入错误,请重新运行!!!");
            // }
            // System.Console.WriteLine (GameStaticTools.FormatStr("第一章节"));

            // DateTime   time = DateTime.Now;
            // System.Console.WriteLine ((int)time.DayOfWeek % 2 != 0);
            // System.Console.WriteLine ((int)time.DayOfWeek % 2 == 0);

            // Program p = new Program ();
            // p.CreateData ();
            // List<StageData> data = new List<StageData> ();
            // data = p.GetStge (ProgramEnum.StageMode.DayRobberStage);
            // for (int i = 0; i < data.Count; i++) {
            //     StageDayrobberData dayData = (StageDayrobberData) data[i].obj;
            //     System.Console.WriteLine (dayData.Id + " " + dayData.Name);
            // }

            /*
                List<int> matchTime = new List<int> () { 0, 48, 96, 144 };
                List<int> matchTime1 = new List<int> () { 24, 72, 120, 144 };
                System.Console.WriteLine(TimeUtil.GetTimeStamp());
                System.Console.WriteLine(TimeUtil.GetUnixTime());
                int openTimeHour = 24;
                //获取当前周一的时间戳
                DateTime mondayT = TimeUtil.GetMondayDate (TimeUtil.GetUnixTime ());
                long mondayStamp = TimeUtil.FormatToTimeStamp (mondayT);
                Console.WriteLine ("周一时间: " + mondayT + " 时间戳 " + mondayStamp);
                long nowStamp = TimeUtil.FormatToTimeStamp (TimeUtil.GetUnixTime ());
                Console.WriteLine ("今天时间: " + TimeUtil.GetUnixTime () + " 时间戳 " + nowStamp);    
                for (int i = 0; i < matchTime.Count; i++) {
                    long startTime = mondayStamp + (matchTime[i] * 3600);
                    long endTime = mondayStamp + ((matchTime[i] + openTimeHour) * 3600);
                    if (startTime <= nowStamp && nowStamp <= endTime) {
                        System.Console.WriteLine ("");
                        System.Console.WriteLine (" 开始时间戳: " + startTime + " 结束时间戳 " + endTime);
                        Console.WriteLine ("怪物开放 " + "开始时间: " + TimeUtil.FormatToDateTime (startTime) + " 结束时间: " + TimeUtil.FormatToDateTime (endTime));
                        break;
                    }
                }
                
                for (int i = 0; i < matchTime1.Count; i++) {
                    long startTime = mondayStamp + (matchTime1[i] * 3600);
                    long endTime = mondayStamp + ((matchTime1[i] + openTimeHour) * 3600);
                    if (startTime <= nowStamp && nowStamp <= endTime) {
                        System.Console.WriteLine ("");
                        System.Console.WriteLine ("开始时间戳: " + startTime + " 结束时间戳 " + endTime);
                        System.Console.WriteLine ("守卫开放 " + "开始时间: " + TimeUtil.FormatToDateTime (startTime) + " 结束时间: " + TimeUtil.FormatToDateTime (endTime));
                        break;
                    }
                }
            */

            string str = "0,48,96,144";
            string[] strs = StringUtils.FormatString(str);
            for (int i = 0; i <strs.Length ; i++)
            {
                System.Console.WriteLine(strs[i]);
            }

        }

        #region 测试方法
        private Dictionary<ProgramEnum.StageMode, List<StageData>> stageData = new Dictionary<ProgramEnum.StageMode, List<StageData>> ();
        public void CreateData () {
            List<StageData> list1 = new List<StageData> ();
            List<StageData> list2 = new List<StageData> ();
            List<StageData> list3 = new List<StageData> ();
            for (int i = 0; i < 5; i++) {
                StageData data = new StageData (new StageDayrobberData (i, i.ToString ()));
                list1.Add (data);
            }
            for (int i = 5; i >= 0; i--) {
                StageData data = new StageData (new StageDayrobberData (i, i.ToString ()));
                list2.Add (data);
            }
            for (int i = 10; i >= 5; i--) {
                StageData data = new StageData (new StageDayrobberData (i, i.ToString ()));
                list3.Add (data);
            }

            stageData.Add (ProgramEnum.StageMode.DayRobberStage, list1);
            stageData.Add (ProgramEnum.StageMode.NormalStage, list2);
            stageData.Add (ProgramEnum.StageMode.EliteStage, list3);

        }

        public List<StageData> GetStge (ProgramEnum.StageMode key) {
            List<StageData> datas = new List<StageData> ();
            stageData.TryGetValue (key, out datas);
            return datas;
        }
        #endregion
    }
}