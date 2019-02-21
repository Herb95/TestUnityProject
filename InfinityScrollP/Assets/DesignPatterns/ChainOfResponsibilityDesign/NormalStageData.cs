#region 注释
/*
*         Title: IStageData :  责任链设计模式  
*         Description:
*                功能： 正常关卡
*         Author:           Herbie  
*         Version:          0.1版本
*         Modify Recoder: 
*/
#endregion

using System.Collections.Generic;
using UnityEngine;

namespace Assets.DesignPatterns.ChainOfResponsibilityDesign
{
    public class NormalStageData : IStageData
    {
        private float m_CoolDown = 0;
        private float m_MaxCoolDown = 0;
        //出生点
        private Vector3 m_SpawnPosition =Vector3.zero;
        //攻击目标
        private Vector3 m_AttackPosition =Vector3.zero;
        private bool m_AllEnemyBorn = false;
        /// <summary>
        ///  关卡产生敌人单位
        /// </summary>
        private List<StageData> m_StageData = new List<StageData>();


        // ReSharper disable once ClassNeverInstantiated.Local
        private class StageData
        {

        }

        

        public override bool IsFinished()
        {
            throw new System.NotImplementedException();
        }

        public override void ResetStage()
        {
            throw new System.NotImplementedException();
        }

        public override void UpdateStage()
        {
            throw new System.NotImplementedException();
        }
    }
}