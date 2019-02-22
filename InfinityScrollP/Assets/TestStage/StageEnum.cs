#region 注释
/*
*         Title: EStage : LianJian
*         Description:
*                功能：***
*         Author:           Herbie  
*         Version:          0.1版本
*         Modify Recoder: 
*/
#endregion

using System.ComponentModel;

namespace Assets.TestStage
{
    public class StageEnum
    {
        public enum EStageMode
        {
            [Description("普通模式")]
            NormalMode = 0,
            [Description("精英模式")]
            EliteMode = 1,
            [Description("远征模式")]
            ExpeditionMode = 2,
            [Description("天劫模式")]
            DayRobberyMode = 3,
        }

        public enum EStageName
        {
            [Description("第一关")]
            One = 0,
            [Description("第二关")]
            Two = 1,
            [Description("第三关")]
            Three = 2,
            [Description("第四关")]
            Four = 3,
        }
    }
}
