#region 注释
/*
*         Title: CubeScripts : Assets.XLuaTestScripts.PathScript
*         Description:
*                功能：***
*         Author:            Herbie  
*         Time:              #time#
*         Version:           0.1版本
*         Modify Recoder: 
* ******************************************************
* Copyright@#username# #year# .All rights reserved.
* ******************************************************
*/
#endregion

using System;
using UnityEngine;
using XLua;

namespace PathTestProject
{
    [Serializable]
    public class Injection
    {
        public string Name;
        public GameObject Value;
    }

    [LuaCallCSharp]
    public class CubeScripts : MonoBehaviour
    {
        public TextAsset _cubeScriptsAsset;
        public Injection[] _injections;
        internal const float GcInterval = 1;
        public Transform _tran;
        public Material _mat;
        public LuaTable _scriptEve;
        public Action _luaStart;
        public Action _luaUpDate;
        public Action _luaOnDestroy;

        internal LuaEnv _luaEnv = new LuaEnv();

        public void Awake()
        {
            _cubeScriptsAsset = Resources.Load<TextAsset>("LuaScripts/TestLuaScript.Lua");

            _scriptEve = _luaEnv.NewTable();

            LuaTable meta = _luaEnv.NewTable();
            meta.Set("__index", _luaEnv.Global);
            _scriptEve.SetMetaTable(meta);
            meta.Dispose();

            _scriptEve.Set("Self", this);
            foreach (var injection in _injections)
            {
                _scriptEve.Set(injection, injection.Value);
            }

            _luaEnv.DoString(_cubeScriptsAsset.text, "TestLuaScript", _scriptEve);

            Action luaAwake = _scriptEve.Get<Action>("awake");
            _scriptEve.Get("start", out _luaStart);
            _scriptEve.Get("update", out _luaUpDate);
            _scriptEve.Get("ondestroy", out _luaOnDestroy);
            if (luaAwake != null)
            {
                luaAwake.Invoke();
            }
        }

        public void GetObj()
        {
            _tran = this.transform;
            _mat = this.gameObject.GetComponent<MeshRenderer>().material;

        }

        public void SetMaterial(Material mat)
        {
            this._mat = mat;
        }


        private void Start()
        {
            if (_luaStart != null)
            {
                _luaStart.Invoke();
            }
        }

        private void Update()
        {
            if (_luaUpDate != null)
            {
                _luaUpDate.Invoke();
            }
            if (Time.time - LuaBehaviour.lastGCTime > GcInterval)
            {
                _luaEnv.Tick();
                LuaBehaviour.lastGCTime = Time.time;
            }
        }


        private void OnDestroy()
        {
            if (_luaOnDestroy != null)
            {
                _luaOnDestroy();
            }

            _luaOnDestroy = null;
            _luaUpDate = null;
            _scriptEve.Dispose();
            _injections = null;
        }
    }
}