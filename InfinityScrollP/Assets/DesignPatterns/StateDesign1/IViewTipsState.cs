#region 注释
/*
*         Title: IViewTipsState : LianJian
*         Description:
*                功能：***
*         Author:           Herbie  
*         Version:          0.1版本
*         Modify Recoder: 
*/
#endregion

using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Assets.DesignPatterns.StateDesign1
{
    public class IViewTipsState : MonoBehaviour
    {
        private string _StateName = "IViewTipsState";

        public string StateName
        {
            get { return _StateName; }
            set { _StateName = value; }
        }

        //控制者
        protected ViewTipsController _tipsController = null;

        //public IViewTipsState(ViewTipsController controller)
        //{
        //    _tipsController = controller;
        //}
        //建造者
        protected virtual void Init(ViewTipsController controller)
        {
            _tipsController = controller;
        }

        //开始
        public virtual void StateBegin()
        {
        }
        //结束
        public virtual void StateEnd()
        {
        }
        //更新
        public virtual void StateUpdate()
        {
        }

        public override string ToString()
        {
            return string.Format("[I_ViewTipsState: StateName = {0}]", StateName);
        }

        public static T Create<T>(ViewTipsController controller) where T : IViewTipsState
        {
            Transform uiRoot = GameObject.Find("Canvas").transform;
            switch (typeof(T).Name)
            {
                case "UINumberTips":
                    s_uINumberTips = uiRoot.Find("Normal/UINumberTips").GetComponent<UINumberTips>();
                    s_uINumberTips.Init(controller);
                    return (T)s_uINumberTips;
                case "UIGoldTips":
                    s_uINumberTips = uiRoot.Find("Normal/UIGoldTips").GetComponent<UIGoldTips>();
                    s_uINumberTips.Init(controller);
                    return (T)s_uINumberTips;
            }
            return null;
        }

        private static IViewTipsState s_uINumberTips;
    }

}
