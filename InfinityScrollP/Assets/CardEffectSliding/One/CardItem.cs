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
        public RawImage _bgImg;
        public Button _btn;
        public Material mat;
        public Text _text;
        private Transform mTran;
        public int RealIndex;

        public int CurveOffSetIndex { get; set; }
        public float CenterOffset { get; set; }

        private void Awake()
        {
            mat = Resources.Load<Material>("Material/UIGrey/UIGreyMat.mat");
            _text = this.transform.Find("Text").GetComponent<Text>();
        }
        public void SetId(int value)
        {
            this._id = value;
        }

        public int GetId()
        {
            return _id;
        }

        public RawImage GetImage()
        {
            if (_bgImg != null)
                return _bgImg;
            else
                return this.gameObject.GetComponent<RawImage>();
        }

        public void Init(Texture sp, Action action)
        {
            _text.text = sp.name;
            mTran = this.transform;
            _bgImg = this.gameObject.GetComponent<RawImage>();
            _bgImg.texture = sp;
            _btn = this.gameObject.GetComponent<Button>();
            if (_btn == null)
                _btn = this.gameObject.AddComponent<Button>();

            if (action != null)
            {
                action();
            }
            _btn.onClick.AddListener(() =>
            {
                One.CardEffectSliding.GetInstance().SetHorizontalTargetItemIndex(this);
            });
        }

        public void SetMaterial(bool isShow = true)
        {
            this._bgImg.material = isShow ? null : mat;
        }

        /// <summary>
        /// 设定是否在中间,不在中间置灰
        /// </summary>
        /// <param name="isCenter"></param>
        public void SetSelectColor(bool isCenter)
        {
            if (_bgImg == null)
                _bgImg = this.GetComponent<RawImage>();

            _bgImg.color = isCenter ? Color.white : Color.gray;
        }

        /// <summary>
        /// 更新改Item 的缩放和位置
        /// </summary>
        /// <param name="xValue"></param>
        /// <param name="depthCurveValue"></param>
        /// <param name="depthFactor"></param>
        /// <param name="itemCount"></param>
        /// <param name="yValue"></param>
        /// <param name="scaleValue"></param>
        public void UpdateScrollViewItems(
            float xValue,
            float depthCurveValue,
            int depthFactor,
            float itemCount,
            float yValue,
            float scaleValue
            )
        {
            Vector3 targetPos = Vector3.one;
            Vector3 targetScale = Vector3.one;
            targetPos.x = xValue;
            targetPos.y = yValue;
            mTran.localPosition = targetPos;

            targetPos.z = depthFactor;
            SetItemDepth(depthCurveValue, depthFactor, itemCount);

            targetScale.x = targetScale.y = scaleValue;
            mTran.localScale = targetScale;
        }

        public void SetItemDepth(float depthCurveValue, int depthFactor, float itemCount)
        {
            int newDepth = (int)(depthCurveValue * itemCount);
            this.transform.SetSiblingIndex(newDepth);
        }
    }
}