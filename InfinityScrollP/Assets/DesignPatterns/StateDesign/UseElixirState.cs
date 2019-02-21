#region 注释
/*
*         Title: UseElixirState : LianJian
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
    public class UseElixirState : State
    {
        public UseElixirState(Conntext thisConntext) : base(thisConntext)
        {
        }

        public override string Handle<TEnum>(TEnum value)
        {
             string title = string.Empty;
            if (value.Equals(StateEnum.ViewType.UseElixir))
            {
                title=GameStaticUtils.GetEnumDescription<TEnum>((int)StateEnum.ViewType.UseElixir);
            }
            return title;
        }
    }
}
