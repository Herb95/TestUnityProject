#region 注释
/*
*         Title: IStageScore :  责任链设计模式
*         Description:
*                功能：常用关卡
*         Author:           Herbie  
*         Version:          0.1版本
*         Modify Recoder: 
*/
#endregion
namespace Assets.DesignPatterns.ChainOfResponsibilityDesign
{
    public class NormalStageHandler : IStageHandler
    {
        //关卡内容
        protected IStageData m_StageData = null;
        protected NormalStageHandler(IStageScore statgeScore, IStageData stageData)
        {
            m_StageData = stageData;
            m_StageScore = statgeScore;
        }


        public IStageHandler SetNexHandler(IStageHandler nextStageHandler)
        {
            m_NextHandler = nextStageHandler;
            return m_NextHandler;
        }

        public override IStageHandler CheckStage()
        {
            if (m_StageScore.CheckScore() == false)
                return this;
            if (m_NextHandler == null) return this;
            return m_NextHandler.CheckStage();
        }

        public override void UpdateStage()
        {
            m_StageData.UpdateStage();
            m_StageData.UpdateStage();
        }

        public override void ResetStage()
        {
            m_StageData.ResetStage();
        }

        public override bool IsFinished()
        {
            return m_StageData.IsFinished();
        }
    }
}