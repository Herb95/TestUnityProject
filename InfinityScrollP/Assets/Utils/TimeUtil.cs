#region 注释
/*
*         Title: TimeUtils : TestProject
*         Description:
*                功能：  时间工具类
*         Author:           Herbie  
*         Version:          0.1版本
*         Modify Recoder: 
*/
#endregion

using System;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

namespace Assets.Utils
{
    public class TimeUtil : MonoBehaviour
    {
        public DateTime GetDataTime(long timeStamp)
        {
            return new DateTime(1970, 1, 1).AddSeconds(timeStamp).ToLocalTime();
        }

        /// <summary>
        /// 获取本地时间
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static void GetLoclTimer(out string dt)
        {
            dt = DateTime.Now.ToString("u");
        }
    }
}
