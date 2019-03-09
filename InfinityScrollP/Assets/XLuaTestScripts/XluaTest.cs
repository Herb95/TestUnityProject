#region 注释
/*
*         Title: XluaTest : #rootnamespace#
*         Description:
*                功能：***
*         Author:           Herbie  
*         Time:              #time#
*         Version:          0.1版本
*         Modify Recoder: 
* ******************************************************
* Copyright@#username# #year# .All rights reserved.
* ******************************************************
*/
#endregion

using UnityEngine;
using XLua;

namespace Assets.XLuaTestScripts
{
    public class XluaTest : MonoBehaviour
    {
        private LuaEnv _luaEnv;
        public void Start()
        {
            _luaEnv = new LuaEnv();
            DebugLuaPrint("Hello World");

        }

        public void DebugLuaPrint(string str)
        {
            _luaEnv.DoString("CS.UnityEngine.Debug.Log('" + str + "')");
            _luaEnv.Dispose();
        }
    }
}