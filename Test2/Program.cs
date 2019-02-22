using System;
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
            System.Console.WriteLine (GameStaticTools.FormatStr("第一章节"));
        }
    }

    class ProgramEnum {
        public enum EC {
            ERROR_COMMON_SUCCESS = 0,
            ERROR_DATABASE_INSERT = -128,
            ERROR_DATABASE_EXCUTE = -127,
        }
    }
}