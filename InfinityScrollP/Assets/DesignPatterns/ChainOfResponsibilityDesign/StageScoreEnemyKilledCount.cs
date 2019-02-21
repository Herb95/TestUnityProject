#region 注释
/*
*         Title: IStageScore :  责任链设计模式
*         Description:
*                功能 敌人阵亡数量
*         Author:           Herbie  
*         Version:          0.1版本
*         Modify Recoder: 
*/
#endregion
namespace Assets.DesignPatterns.ChainOfResponsibilityDesign
{
    public class StageScoreEnemyKilledCount:IStageScore
    {
        private int m_EnemyKilledCount = 0;
        private StageSystem m_StageSystem = null;

        public StageScoreEnemyKilledCount(int killedCount, StageSystem theStageSystem)
        {
            m_EnemyKilledCount = killedCount;
            m_StageSystem = theStageSystem;
        }
        public override bool CheckScore()
        {
            return(m_StageSystem.GetEnemyKilledCount() >= m_EnemyKilledCount);
        }
    }
}