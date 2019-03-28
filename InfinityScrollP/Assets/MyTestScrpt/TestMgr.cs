#region 注释
/*
 *         Title: TestMgr : #rootnamespace#
 *         Description:
 *                功能：       ***
 *         Author:            Herbie  
 *         Time:              #time#
 *         Version:           0.1版本
 *         Modify Recoder: 
 * ******************************************************
 * Copyright@#username# #year# .All rights reserved.
 * ******************************************************
*/
#endregion
using System.Collections.Generic;
using UnityEngine;

namespace Assets.MyTestScirpt
{
    public class TestMgr : MonoBehaviour
    {
        public Dictionary<int, List<StageDatas>> stageVilew = new Dictionary<int, List<StageDatas>>();

        private void Awake()
        {
            CreateData();
        }

        public void CreateData()
        {
            List<StageDatas> datas = new List<StageDatas>();
            for (int i = 0; i < 5; i++)
            {
                NormalData data = new NormalData(i, "NormalData " + i);
                datas.Add(data);
            }

            stageVilew.Add(1, datas);
        }

        private void OnEnable()
        {
            for (int i = 0; i < stageVilew[1].Count; i++)
            {
                NormalData data = (NormalData)stageVilew[1][i];
                Debug.Log(data.Id + " " + data.Name);
            }
        }
    }
}