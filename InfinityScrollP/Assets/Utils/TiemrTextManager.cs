#region 注释
/*
*         Title: TiemrTextManager : 工具类
*         Description:
*                功能：时间工具测试类
*         Author:           Herbie  
*         Version:          0.1版本
*         Modify Recoder: 
*/
#endregion

using System;
using UnityEngine;

namespace Assets.Utils
{
    public class TiemrTextManager : MonoBehaviour
    {
        private string dt;

        private void Start()
        {
            GetTime();
        }

        public void GetTime()
        {
            TimeUtil.GetLoclTimer(out dt);
            Debug.Log("时间: " + dt);
        }
    }
}
