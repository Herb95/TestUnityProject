#region 注释
/*
*         Title: IStageScore :  责任链设计模式
*         Description:
*                功能：关卡分数
*         Author:           Herbie  
*         Version:          0.1版本
*         Modify Recoder: 
*/
#endregion
namespace Assets.DesignPatterns.ChainOfResponsibilityDesign
{
    public abstract class IStageScore
    {
        public abstract bool CheckScore();
    }
}