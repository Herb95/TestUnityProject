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
        public int TimeId;

        private void OnEnable()
        {
            GetTime();
        }

        public void GetTime()
        {

            TimeId = TimeUtils.Time.AddTimer(1, () =>
            {
                Debug.Log("时间--");
            });
            Debug.Log(TimeId);
        }
    }
}
