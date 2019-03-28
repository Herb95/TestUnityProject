#region 注释
/*
 *         Title: CardItem : #rootnamespace#
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

using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.CardEffectSliding
{
    public class CardItem : MonoBehaviour
    {
        public int _id;
        public Image _bgImg;
        public Button _btn;

        public void SetId(int value)
        {
            this._id = value;
        }

        public int GetId()
        {
            return _id;
        }

        public void Init(Sprite sp, Action action)
        {
            _bgImg = this.gameObject.GetComponent<Image>();
            _bgImg.sprite = sp;
            _btn = this.gameObject.GetComponent<Button>();
            if (action != null)
            {
                _btn.onClick.AddListener(() =>
                {
                    action();
                });
            }
        }

        public void SetDepth()
        {
            //this.gameObject
        }
    }
}