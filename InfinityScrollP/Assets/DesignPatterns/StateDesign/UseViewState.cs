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

using System;
using Assets.Utils;
using UnityEngine;

namespace Assets.DesignPatterns.StateDesign
{
    public class UseViewState : State
    {
        public UseViewState(Conntext thisConntext) : base(thisConntext)
        {
        }

        public override string Handle<TEnum>(TEnum value)
        {
            var title = string.Empty;
            if (value.Equals(StateEnum.ViewType.UseView))
            {
                title = GameStaticUtils.GetEnumDescription<TEnum>((int)StateEnum.ViewType.UseView);
            }
            return title;
        }

    }
}
