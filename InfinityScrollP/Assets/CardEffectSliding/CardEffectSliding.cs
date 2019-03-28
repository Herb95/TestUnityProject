#region 注释
/*
 *         Title: CardEffectSliding : TestUnity
 *         Description:
 *                功能：      卡牌滑动循环列表
 *         Author:            Herbie  
 *         Time:              #time#
 *         Version:           0.1版本
 *         Modify Recoder:
 *         Url: https://blog.csdn.net/qq_20849387/article/details/72312375
 * ******************************************************
 * Copyright@#username# #year# .All rights reserved.
 * ******************************************************
*/
#endregion

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.CardEffectSliding
{

    public class CardConst
    {
        public const string PathCardItem = "Prefabs/CarItem";
        public const string PicPrefix = "TestPng2/pic_";

    }

    public class CardEffectSliding : MonoBehaviour
    {

        public List<GameObject> _cardList = new List<GameObject>();
        public ScrollRect _scrollRect;
        public Transform _content;

        public void Awake()
        {
            _scrollRect = transform.Find("ScrollView").GetComponent<ScrollRect>();
            _content = _scrollRect.content;

            //InitSprite();
        }

        private void OnEnable()
        {
            Init();

        }

        public void Init()
        {
            for (int i = 0; i < 9; i++)
            {
                GameObject go = Instantiate(LoadRes<GameObject>(CardConst.PathCardItem));
                CardItem item = go.GetComponent<CardItem>();
                go.transform.SetParent(_content);
                UniformTransform(go.transform);
                item.SetId(i);
                item.Init(LoadRes<Sprite>(CardConst.PicPrefix + i.ToString()), () =>
                {
                    Debug.Log("点击了: " + item.GetId() + " : " + item.GetComponent<RectTransform>().GetSiblingIndex());
                });
                _cardList.Add(go);
            }
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

    }
}