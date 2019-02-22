#region 注释
/*
*         Title: StageBase : LianJian
*         Description:
*                功能：关卡模式
*         Author:           Herbie  
*         Version:          0.1版本
*         Modify Recoder: 
*/
#endregion

using System.Collections.Generic;
using UnityEngine;

namespace Assets.TestStage
{
    public class StageBase : MonoBehaviour
    {
        private void Awake()
        {
            GetRes();
        }

        public virtual void GetRes() { }

        public virtual void OnEnable()
        {
        }

        public virtual void Init(StageEnum.EStageMode mode, List<StageData> data)
        {
        }
    }
}
