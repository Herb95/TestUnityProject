#region 注释
/*
*         Title: ConcreteStateA : LianJian
*         Description:
*                功能：***
*         Author:           Herbie  
*         Version:          0.1版本
*         Modify Recoder: 
*/
#endregion

using Assets.Utils;
using UnityEngine;

namespace Assets.DesignPatterns.StateDesign
{
    public class SellViewState : State
    {
        public SellViewState(Conntext thisConntext) : base(thisConntext)
        {
        }

        public override string Handle<TEnum>(TEnum value)
        {
            string title = string.Empty;
            if (value.Equals(StateEnum.ViewType.SellView))
            {
                title = GameStaticUtils.GetEnumDescription<TEnum>((int)StateEnum.ViewType.SellView);
            }
            return title;
        }
    }
}
