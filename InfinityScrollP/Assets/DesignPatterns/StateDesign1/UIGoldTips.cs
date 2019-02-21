#region 注释
/*
*         Title: UINumberTips : LianJian
*         Description:
*                功能：***
*         Author:           Herbie  
*         Version:          0.1版本
*         Modify Recoder: 
*/
#endregion

using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.DesignPatterns.StateDesign1
{
    public class UIGoldTips : IViewTipsState
    {
        public Image _image;
        public Text _text;

        private void GetComponent()
        {
            _image = this.transform.Find("Image").GetComponent<Image>();
            _text = this.transform.Find("Image/Text").GetComponent<Text>();
        }

        //public UIGoldTips(ViewTipsController controller) : base(controller)
        //{
        //    this.StateName = "UIGoldTips";
        //}
        protected override void Init(ViewTipsController controller)
        {
            base.Init(controller);
            this.StateName = "UIGoldTips";
        }

        public override void StateBegin()
        {
            base.StateBegin();
            GetComponent();
            _text.text = this.StateName;
            this.gameObject.gameObject.SetActive(true);
            UnityEngine.Debug.Log("显示界面");
        }

        public override void StateEnd()
        {
            base.StateEnd();
            this.gameObject.gameObject.SetActive(false);
            UnityEngine.Debug.Log("关闭界面 UIGoldTips");
        }
    }
}