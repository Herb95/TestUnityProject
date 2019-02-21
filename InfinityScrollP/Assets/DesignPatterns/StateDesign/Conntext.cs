#region 注释
/*
*         Title: Conntext : LianJian
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
    public class Conntext
    {
        private State m_State = null;

        public void Request<TEnum>(TEnum evalue, Action<string> acion = null)
        {
            if (acion != null)
                acion(m_State.Handle(evalue));
            else
                m_State.Handle(evalue);
        }

        public void SetState(State theState)
        {
            m_State = theState;
        }
    }
}
