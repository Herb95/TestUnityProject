#region 注释
/*
*         Title: State : LianJian
*         Description:
*                功能：***
*         Author:           Herbie  
*         Version:          0.1版本
*         Modify Recoder: 
*/
#endregion

using System;

namespace Assets.DesignPatterns.StateDesign
{
    public abstract class State
    {
        protected Conntext m_Context = null;

        protected State(Conntext thisConntext)
        {
            m_Context = thisConntext;
        }

        public abstract string Handle<TEnum>(TEnum value);
    }
}
