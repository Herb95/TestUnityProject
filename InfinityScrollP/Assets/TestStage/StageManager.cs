using System.Collections.Generic;
using Assets.Utils;

namespace Assets.TestStage
{
    public class StageManager
    {
        #region Instance
        private static StageManager _instance;
        public static StageManager Instance
        {
            get { return _instance ?? (_instance = new StageManager()); }
        }

        private StageManager()
        {

        }
        #endregion


        List<StageData> _normaDatas = new List<StageData>();

        public void InitDatas()
        {
            for (int i = 0; i < 4; i++)
            {
                StageData data = new StageData(i, GameStaticUtils.GetEnumDescription<StageEnum.EStageName>(i));
                _normaDatas.Add(data);
            }
        }

        public List<StageData> GetNormalDatas(StageEnum.EStageMode mode)
        {
            switch (mode)
            {
                case StageEnum.EStageMode.NormalMode:
                    return _normaDatas;
                case StageEnum.EStageMode.EliteMode:
                    return new List<StageData>();
                case StageEnum.EStageMode.ExpeditionMode:
                    return new List<StageData>();
                case StageEnum.EStageMode.DayRobberyMode:
                    return new List<StageData>();
                default:
                    return new List<StageData>();
            }
        }
    }
}
