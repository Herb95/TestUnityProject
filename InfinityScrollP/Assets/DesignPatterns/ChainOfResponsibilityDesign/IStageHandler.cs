#region 注释
/*
*         Title: IStageHandler : 责任链设计模式
*         Description:
*                功能： 关卡接口
*         Author:           Herbie  
*         Version:          0.1版本
*         Modify Recoder: 
*/
#endregion

using UnityEngine;

namespace Assets.DesignPatterns.ChainOfResponsibilityDesign
{
    public abstract class IStageHandler
    {
        protected IStageData m_StageData = null;
        protected IStageScore m_StageScore =null;
        protected IStageHandler m_NextHandler = null;

        /// <summary>
        /// 设置下一关卡
        /// </summary>
        /// <param name="nextHandler"></param>
        /// <returns></returns> 
        public IStageHandler SetNextHandler(IStageHandler nextHandler)
        {
            m_NextHandler = nextHandler;
            return m_NextHandler;
        }

        /// <summary>
        /// 判断当前关卡
        /// </summary>
        /// <returns></returns>
        public abstract IStageHandler CheckStage();
        /// <summary>
        /// 更新关卡
        /// </summary>
        public abstract void UpdateStage();
        /// <summary>
        /// 重置关卡
        /// </summary>
        public abstract void ResetStage();
        /// <summary>
        /// 是否结束
        /// </summary>
        /// <returns></returns>
        public abstract bool IsFinished();

    }
}
