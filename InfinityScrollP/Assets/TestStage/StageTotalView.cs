#region 注释
/*
*         Title: StageToalView : LianJian
*         Description:
*                功能： 关卡总管理界面
*         Author:           Herbie  
*         Version:          0.1版本
*         Modify Recoder: 
*/
#endregion

using UnityEngine;
using UnityEngine.UI;

namespace Assets.TestStage
{
    public class StageTotalView : MonoBehaviour
    {
        public Button _btn;
        public Button _btn1;
        public Button _btn2;
        public Button _btn3;
        public StageBase _stagebase;

        private void Awake()
        {
            _btn = transform.GetChild(0).GetComponent<Button>();
            _btn1 = transform.GetChild(1).GetComponent<Button>();
            _btn2 = transform.GetChild(2).GetComponent<Button>();
            _btn3 = transform.GetChild(3).GetComponent<Button>();
            StageManager.Instance.InitDatas();
        }

        private void OnEnable()
        {
            _btn.onClick.AddListener(() =>
            {
                OPenNormalStage(_btn.gameObject, StageEnum.EStageMode.NormalMode);
            });
            _btn1.onClick.AddListener(() =>
            {
                OPenNormalStage(_btn1.gameObject, StageEnum.EStageMode.EliteMode);
            });
            _btn2.onClick.AddListener(() =>
            {
                OPenNormalStage(_btn2.gameObject, StageEnum.EStageMode.ExpeditionMode);
            });
            _btn3.onClick.AddListener(() =>
            {
                OPenNormalStage(_btn3.gameObject, StageEnum.EStageMode.DayRobberyMode);
            });
        }

        private void OPenNormalStage(GameObject go, StageEnum.EStageMode mode)
        {
            go.GetComponent<StageBase>().Init(mode, StageManager.Instance.GetNormalDatas(mode));
        }
    }
}
