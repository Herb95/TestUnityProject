#region 注释
/*
 *         Title: NormalData : #rootnamespace#
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

namespace Assets.MyTestScirpt
{
    public class NormalData : StageDatas
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public NormalData()
        {

        }

        public NormalData(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}