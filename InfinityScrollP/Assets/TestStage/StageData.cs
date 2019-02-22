#region 注释
/*
*         Title: StageData : LianJian
*         Description:
*                功能： 关卡数据
*         Author:           Herbie  
*         Version:          0.1版本
*         Modify Recoder: 
*/
#endregion

using UnityEngine;

namespace Assets.TestStage
{
    public class StageData
    {
        public int Id;
        public string Name;

        public StageData()
        {
        }

        public StageData(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

}
