#region 注释
/*
*         Title: StateEnum : LianJian
*         Description:
*                功能：***
*         Author:           Herbie  
*         Version:          0.1版本
*         Modify Recoder: 
*/
#endregion

using System.ComponentModel;

namespace Assets.DesignPatterns.StateDesign
{
    public class StateEnum
    {
        public enum ViewType
        {
            [Description("出售界面")]
            SellView = 0,
            [Description("合成界面")]
            MergeView = 1,
            [Description("使用物品")]
            UseView = 2,
            [Description("使用数量")]
            SelectView = 3,
            [Description("技能符箓")]
            UseSkill = 4,
            [Description("使用丹药")]
            UseElixir = 5,
        }
    }
}
