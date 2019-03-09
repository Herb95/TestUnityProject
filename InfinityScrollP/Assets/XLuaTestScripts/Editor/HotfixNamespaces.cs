#region 注释
/*
*         Title: NewBehaviourScript : PathTestProject
*         Description:
*                功能：    按名字空间配置，按程序集配置等等
*         Author:           Herbie  
*         Time:              #time#
*         Version:          0.1版本
*         Modify Recoder: 
* ******************************************************
* Copyright@#username# #year# .All rights reserved.
* ******************************************************
*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using XLua;

namespace PathTestProject
{
    public static class HotfixNamespaces 
	{
        #region 动态列表 
        [Hotfix]
        public static List<Type> ByProperty
        {
            get
            {
                return (from type in Assembly.Load("Assembly-CSharp").GetTypes()
                        where type.Namespace == "PathTestProject"
                        select type).ToList();
            }
        }
        #endregion
    }
}