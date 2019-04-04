#region 注释
/*
 *         Title: CardUtils : CardEffectSliding
 *         Description:
 *                功能：      CardEffectSliding 工具
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
using System.Collections.Generic;
using UnityEngine;

namespace Assets.CardEffectSliding
{
    public class CardUtils
    {
        #region CardUtils单例

        private static CardUtils _instance;

        public static CardUtils Instance
        {
            get { return _instance ?? (_instance = new CardUtils()); }
        }
        private CardUtils()
        {

        }
        #endregion
        public class CardConst
        {
            public const string PathCardItem = "Prefabs/CarItem";
            public const string PicPrefix = "TestPng2/pic_";

        }
        public List<CardItem> CreateItems(Transform parentT, int count, Action action = null)
        {
            List<CardItem> items = new List<CardItem>();
            for (int i = 0; i < count; i++)
            {
                GameObject go = GameObject.Instantiate(LoadRes<GameObject>(CardConst.PathCardItem));
                CardItem item = go.GetComponent<CardItem>();
                go.transform.SetParent(parentT);
                UniformTransform(go.transform);
                item.SetId(i);
                Texture sp;
                try
                {
                    sp = LoadRes<Texture>(CardConst.PicPrefix + i.ToString());
                }
                catch (Exception ex)
                {
                    sp = LoadRes<Texture>(CardConst.PicPrefix + (i / 2).ToString());
                    Debug.LogError(ex.ToString());
                }
                item.Init(sp, () =>
                {
                    if (action != null)
                        action.Invoke();
                });
                items.Add(item);
            }

            return items;
        }

        public T LoadRes<T>(string resName) where T : UnityEngine.Object
        {
            return Resources.Load<T>(resName);
        }

        public void UniformTransform(Transform t)
        {
            t.localPosition = Vector3.zero;
            t.localScale = Vector3.one;
            t.localRotation = Quaternion.identity;
        }

        public static int SortPosition(CardItem a, CardItem b)
        {
            return a.transform.localPosition.x.CompareTo(b.transform.localPosition.x);
        }
    }
}