#region 注释
/*
*         Title: ViewTips : LianJian
*         Description:
*                功能：***
*         Author:           Herbie  
*         Version:          0.1版本
*         Modify Recoder: 
*/
#endregion

using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.DesignPatterns.StateDesign1
{
    /// <summary>
    /// 外部访问
    /// </summary>
    public class ViewTips : MonoBehaviour
    {
        private ViewTipsController _controller = new ViewTipsController();
        private Button btn;
        private Button btn1;
        private Button btn2;
        private void Awake()
        {
            btn = transform.Find("Button").GetComponent<Button>();
            btn1 = transform.Find("Button (1)").GetComponent<Button>();
            btn2 = transform.Find("Button (2)").GetComponent<Button>();
        }

        private void OnEnable()
        {
            btn.onClick.AddListener(() =>
            {
                Show<UINumberTips>(_controller);
            });
            btn1.onClick.AddListener(() =>
            {
                Show<UIGoldTips>(_controller);
            });
            btn2.onClick.AddListener(() =>
            {
                _controller.SetState(null);
                _controller.StateUpdate();
            });

        }


        public void Show<T>(ViewTipsController controller) where T : IViewTipsState
        {
            T t = IViewTipsState.Create<T>(controller);
            _controller.SetState(t);
            _controller.StateUpdate();
            Debug.Log(t);
        }
    }
}
