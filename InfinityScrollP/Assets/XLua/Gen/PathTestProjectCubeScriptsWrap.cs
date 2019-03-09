#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class PathTestProjectCubeScriptsWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PathTestProject.CubeScripts);
			Utils.BeginObjectRegister(type, L, translator, 0, 3, 8, 8);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Awake", _m_Awake);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetObj", _m_GetObj);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetMaterial", _m_SetMaterial);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "_cubeScriptsAsset", _g_get__cubeScriptsAsset);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "_injections", _g_get__injections);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "_tran", _g_get__tran);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "_mat", _g_get__mat);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "_scriptEve", _g_get__scriptEve);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "_luaStart", _g_get__luaStart);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "_luaUpDate", _g_get__luaUpDate);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "_luaOnDestroy", _g_get__luaOnDestroy);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "_cubeScriptsAsset", _s_set__cubeScriptsAsset);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "_injections", _s_set__injections);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "_tran", _s_set__tran);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "_mat", _s_set__mat);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "_scriptEve", _s_set__scriptEve);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "_luaStart", _s_set__luaStart);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "_luaUpDate", _s_set__luaUpDate);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "_luaOnDestroy", _s_set__luaOnDestroy);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					PathTestProject.CubeScripts gen_ret = new PathTestProject.CubeScripts();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to PathTestProject.CubeScripts constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Awake(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PathTestProject.CubeScripts gen_to_be_invoked = (PathTestProject.CubeScripts)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Awake(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetObj(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PathTestProject.CubeScripts gen_to_be_invoked = (PathTestProject.CubeScripts)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.GetObj(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetMaterial(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PathTestProject.CubeScripts gen_to_be_invoked = (PathTestProject.CubeScripts)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Material _mat = (UnityEngine.Material)translator.GetObject(L, 2, typeof(UnityEngine.Material));
                    
                    gen_to_be_invoked.SetMaterial( _mat );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get__cubeScriptsAsset(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PathTestProject.CubeScripts gen_to_be_invoked = (PathTestProject.CubeScripts)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked._cubeScriptsAsset);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get__injections(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PathTestProject.CubeScripts gen_to_be_invoked = (PathTestProject.CubeScripts)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked._injections);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get__tran(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PathTestProject.CubeScripts gen_to_be_invoked = (PathTestProject.CubeScripts)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked._tran);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get__mat(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PathTestProject.CubeScripts gen_to_be_invoked = (PathTestProject.CubeScripts)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked._mat);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get__scriptEve(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PathTestProject.CubeScripts gen_to_be_invoked = (PathTestProject.CubeScripts)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked._scriptEve);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get__luaStart(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PathTestProject.CubeScripts gen_to_be_invoked = (PathTestProject.CubeScripts)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked._luaStart);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get__luaUpDate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PathTestProject.CubeScripts gen_to_be_invoked = (PathTestProject.CubeScripts)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked._luaUpDate);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get__luaOnDestroy(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PathTestProject.CubeScripts gen_to_be_invoked = (PathTestProject.CubeScripts)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked._luaOnDestroy);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set__cubeScriptsAsset(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PathTestProject.CubeScripts gen_to_be_invoked = (PathTestProject.CubeScripts)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked._cubeScriptsAsset = (UnityEngine.TextAsset)translator.GetObject(L, 2, typeof(UnityEngine.TextAsset));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set__injections(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PathTestProject.CubeScripts gen_to_be_invoked = (PathTestProject.CubeScripts)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked._injections = (PathTestProject.Injection[])translator.GetObject(L, 2, typeof(PathTestProject.Injection[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set__tran(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PathTestProject.CubeScripts gen_to_be_invoked = (PathTestProject.CubeScripts)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked._tran = (UnityEngine.Transform)translator.GetObject(L, 2, typeof(UnityEngine.Transform));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set__mat(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PathTestProject.CubeScripts gen_to_be_invoked = (PathTestProject.CubeScripts)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked._mat = (UnityEngine.Material)translator.GetObject(L, 2, typeof(UnityEngine.Material));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set__scriptEve(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PathTestProject.CubeScripts gen_to_be_invoked = (PathTestProject.CubeScripts)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked._scriptEve = (XLua.LuaTable)translator.GetObject(L, 2, typeof(XLua.LuaTable));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set__luaStart(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PathTestProject.CubeScripts gen_to_be_invoked = (PathTestProject.CubeScripts)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked._luaStart = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set__luaUpDate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PathTestProject.CubeScripts gen_to_be_invoked = (PathTestProject.CubeScripts)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked._luaUpDate = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set__luaOnDestroy(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PathTestProject.CubeScripts gen_to_be_invoked = (PathTestProject.CubeScripts)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked._luaOnDestroy = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
