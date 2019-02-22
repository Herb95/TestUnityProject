#region 注释
/*
*         Title: NormalStage : LianJian
*         Description:
*                功能：***
*         Author:           Herbie  
*         Version:          0.1版本
*         Modify Recoder: 
*/
#endregion

using System.Collections.Generic;
using Assets.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.TestStage.Stage
{
    public class NormalStage : StageBase
    {
        //public Button _btn;
        public Text _text;

        public override void GetRes()
        {
            base.GetRes();
            //_btn = this.gameObject.GetComponent<Button>();
            _text = transform.Find("Text").GetComponent<Text>();
        }

        public override void OnEnable()
        {
            base.OnEnable();
            //_btn.onClick.AddListener(() =>
            //{
            //    Debug.Log("进入普通模式,初始化数据");
            //});
        }

        public override void Init(StageEnum.EStageMode mode, List<StageData> data)
        {
            base.Init(mode, data);
            if (mode != StageEnum.EStageMode.NormalMode)
                return;
            Debug.Log("进入普通模式,初始化数据");
            _text.text = GameStaticUtils.GetEnumDescription<StageEnum.EStageMode>((int)mode);

            foreach (StageData t in data)
            {
                Debug.Log(t.Id + " 关卡名: " + t.Name);
            }
        }
    }
}
