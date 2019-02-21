﻿#region 注释
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
    public class MergeViewState : State
    {
        public MergeViewState(Conntext thisConntext) : base(thisConntext)
        {

        }


        public override string Handle<TEnum>(TEnum value)
        {
            string title = string.Empty;
            if (value.Equals(StateEnum.ViewType.MergeView))
            {
                title=GameStaticUtils.GetEnumDescription<TEnum>((int)StateEnum.ViewType.MergeView);
            }
            return title;
        }
    }


}
