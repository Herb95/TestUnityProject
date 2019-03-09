#region 注释
/*
*         Title: HotfixStaticParameter : PathTestProject
*         Description:
*                功能：比如系统api，没源码的库，或者实例化的泛化类型
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
    public static class HotfixStaticParameter
    {
        #region 静态字段
        [Hotfix]
        public static List<Type> ByFiled = new List<Type>()
        {
             typeof(GenericClass<>),
        };
        #endregion

       
    }
}