#region 注释
/*
*         Title: DesignTest : LianJian
*         Description:
*                功能：***
*         Author:           Herbie  
*         Version:          0.1版本
*         Modify Recoder: 
*/
#endregion

using System.Net.Mime;
using Assets.DesignPatterns.StateDesign;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.DesignPatterns.TestDesign
{
    public class DesignTest : MonoBehaviour
    {
        public Text _title;
        private void Awake()
        {
            _title = this.transform.Find("Image/Text").GetComponent<Text>();
            UnitStateTest();
        }
        public void UnitStateTest()
        {
            Conntext theConntext0  = new Conntext();
            theConntext0.SetState(new UseViewState(theConntext0));
            theConntext0.Request(StateEnum.ViewType.UseView, (text) =>
            {
                _title.text = text;
            });

            //Conntext theConntext1 = new Conntext();
            //theConntext1.SetState(new SellViewState(theConntext1));
            //theConntext1.Request(StateEnum.ViewType.SellView);

            //Conntext theConntext2 = new Conntext();
            //theConntext2.SetState(new MergeViewState(theConntext2));
            //theConntext2.Request(StateEnum.ViewType.MergeView);

            //Conntext theConntext3 = new Conntext();
            //theConntext3.SetState(new SelectViewState(theConntext3));
            //theConntext3.Request(StateEnum.ViewType.SelectView);

            //Conntext theConntext4 = new Conntext();
            //theConntext4.SetState(new UseElixirState(theConntext4));
            //theConntext4.Request(StateEnum.ViewType.UseElixir);

            //Conntext theConntext5 = new Conntext();
            //theConntext5.SetState(new UseSkillState(theConntext5));
            //theConntext5.Request(StateEnum.ViewType.UseSkill);
        }
    }
}
