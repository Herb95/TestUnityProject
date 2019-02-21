#region 注释
/*
*         Title: IStageData :  责任链设计模式  
*         Description:
*                功能： 关卡内容
*         Author:           Herbie  
*         Version:          0.1版本
*         Modify Recoder: 
*/
#endregion

using System;

namespace Assets.DesignPatterns.ChainOfResponsibilityDesign
{
    public abstract class IStageData
    {
        public abstract void UpdateStage();

        public abstract void ResetStage();

        public abstract bool IsFinished();
    }
}
