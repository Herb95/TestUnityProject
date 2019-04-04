﻿using System.Collections.Generic;
using UnityEngine;

namespace Assets.CardEffectSliding.Other
{
    public class EnhanceScrollView : MonoBehaviour
    {
        // Control the item's scale curve
        public AnimationCurve scaleCurve;
        // Control the position curve
        public AnimationCurve positionCurve;
        // Control the "depth"'s curve(In 3d version just the Z value, in 2D UI you can use the depth(NGUI))
        // NOTE:
        // 1. In NGUI set the widget's depth may cause performance problem
        // 2. If you use 3D UI just set the Item's Z position
        public AnimationCurve depthCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
        // The start center index
        [Tooltip("The Start center index")]
        public int startCenterIndex = 0;
        // Offset width between item
        public float cellWidth = 10f;
        private float totalHorizontalWidth = 500.0f;
        // vertical fixed position value 
        public float yFixedPositionValue = 46.0f;

        // Lerp duration
        public float lerpDuration = 0.2f;
        private float mCurrentDuration = 0.0f;
        private int mCenterIndex = 0;
        public bool enableLerpTween = true;

        // center and preCentered item
        private EnhanceItem curCenterItem;
        private EnhanceItem preCenterItem;

        // if we can change the target item
        private bool canChangeItem = true;
        private float dFactor = 0.2f;

        // originHorizontalValue Lerp to horizontalTargetValue
        private float originHorizontalValue = 0.1f;
        public float curHorizontalValue = 0.5f;

        // "depth" factor (2d widget depth or 3d Z value)
        private int depthFactor = 5;

        // targets enhance item in scroll view
        public List<EnhanceItem> _items;
        // sort to get right index
        private List<EnhanceItem> listSortedItems = new List<EnhanceItem>();

        private static EnhanceScrollView instance;
        public static EnhanceScrollView GetInstance
        {
            get { return instance; }
        }

        void Awake()
        {
            instance = this;
        }

        void Start()
        {
            canChangeItem = true;
            int count = _items.Count;
            dFactor = (Mathf.RoundToInt((1f / count) * 10000f)) * 0.0001f;
            mCenterIndex = count / 2;
            if (count % 2 == 0)
                mCenterIndex = count / 2 - 1;
            int index = 0;
            for (int i = count - 1; i >= 0; i--)
            {
                _items[i].CurveOffSetIndex = i;
                _items[i].CenterOffSet = dFactor * (mCenterIndex - index);
                _items[i].SetSelectState(false);

                GameObject obj = _items[i].gameObject;
                UDragEnhanceView script = obj.GetComponent<UDragEnhanceView>();
                if (script != null)
                    script.SetScrollView(this);
                index++;
            }

            // set the center item with startCenterIndex
            if (startCenterIndex < 0 || startCenterIndex >= count)
            {
                Debug.LogError("## startCenterIndex < 0 || startCenterIndex >= listEnhanceItems.Count  out of index ##");
                startCenterIndex = mCenterIndex;
            }

            // sorted items
            listSortedItems = new List<EnhanceItem>(_items.ToArray());
            totalHorizontalWidth = cellWidth * count;
            curCenterItem = _items[startCenterIndex];
            curHorizontalValue = 0.5f - curCenterItem.CenterOffSet;
            LerpTweenToTarget(0f, curHorizontalValue, false);


        }

        private void LerpTweenToTarget(float originValue, float targetValue, bool needTween = false)
        {
            if (!needTween)
            {
                SortEnhanceItem();
                originHorizontalValue = targetValue;
                UpdateEnhanceScrollView(targetValue);
                this.OnTweenOver();
            }
            else
            {
                originHorizontalValue = originValue;
                curHorizontalValue = targetValue;
                mCurrentDuration = 0.0f;
            }
            enableLerpTween = needTween;
        }

        public void DisableLerpTween()
        {
            this.enableLerpTween = false;
        }

        /// 
        /// Update EnhanceItem state with curve fTime value
        /// 
        public void UpdateEnhanceScrollView(float fValue)
        {
            for (int i = 0; i < _items.Count; i++)
            {
                EnhanceItem itemScript = _items[i];
                float xValue = GetXPosValue(fValue, itemScript.CenterOffSet);
                float scaleValue = GetScaleValue(fValue, itemScript.CenterOffSet);
                float depthCurveValue = depthCurve.Evaluate(fValue + itemScript.CenterOffSet);
                itemScript.UpdateScrollViewItems(
                    xValue,
                    depthCurveValue,
                    depthFactor,
                    _items.Count,
                    yFixedPositionValue, 
                    scaleValue);
            }
        }

        void Update()
        {
            if (enableLerpTween)
                TweenViewToTarget();
        }

        private void TweenViewToTarget()
        {
            mCurrentDuration += Time.deltaTime;
            if (mCurrentDuration > lerpDuration)
                mCurrentDuration = lerpDuration;

            float percent = mCurrentDuration / lerpDuration;
            float value = Mathf.Lerp(originHorizontalValue, curHorizontalValue, percent);
            UpdateEnhanceScrollView(value);
            if (mCurrentDuration >= lerpDuration)
            {
                canChangeItem = true;
                enableLerpTween = false;
                OnTweenOver();
            }
        }

        private void OnTweenOver()
        {
            if (preCenterItem != null)
                preCenterItem.SetSelectState(false);
            if (curCenterItem != null)
                curCenterItem.SetSelectState(true);
        }

        // Get the evaluate value to set item's scale
        private float GetScaleValue(float sliderValue, float added)
        {
            float scaleValue = scaleCurve.Evaluate(sliderValue + added);
            return scaleValue;
        }

        // Get the X value set the Item's position
        private float GetXPosValue(float sliderValue, float added)
        {
            float evaluateValue = positionCurve.Evaluate(sliderValue + added) * totalHorizontalWidth;
            return evaluateValue;
        }

        private int GetMoveCurveFactorCount(EnhanceItem preCenterItem, EnhanceItem newCenterItem)
        {
            SortEnhanceItem();
            int factorCount = Mathf.Abs(newCenterItem.RealIndex) - Mathf.Abs(preCenterItem.RealIndex);
            return Mathf.Abs(factorCount);
        }

        // sort item with X so we can know how much distance we need to move the timeLine(curve time line)
        public static int SortPosition(EnhanceItem a, EnhanceItem b) { return a.transform.localPosition.x.CompareTo(b.transform.localPosition.x); }
        private void SortEnhanceItem()
        {
            listSortedItems.Sort(SortPosition);
            for (int i = listSortedItems.Count - 1; i >= 0; i--)
                listSortedItems[i].RealIndex = i;
        }

        public void SetHorizontalTargetItemIndex(EnhanceItem selectItem)
        {
            if (!canChangeItem)
                return;

            if (curCenterItem == selectItem)
                return;

            canChangeItem = false;
            preCenterItem = curCenterItem;
            curCenterItem = selectItem;

            // calculate the direction of moving
            float centerXValue = positionCurve.Evaluate(0.5f) * totalHorizontalWidth;
            bool isRight = selectItem.transform.localPosition.x > centerXValue;

            // calculate the offset * dFactor
            int moveIndexCount = GetMoveCurveFactorCount(preCenterItem, selectItem);
            float dvalue = 0.0f;
            if (isRight)
            {
                dvalue = -dFactor * moveIndexCount;
            }
            else
            {
                dvalue = dFactor * moveIndexCount;
            }
            float originValue = curHorizontalValue;
            LerpTweenToTarget(originValue, curHorizontalValue + dvalue, true);
        }

        // Click the right button to select the next item.
        public void OnBtnRightClick()
        {
            if (!canChangeItem)
                return;
            int targetIndex = curCenterItem.CurveOffSetIndex + 1;
            if (targetIndex > _items.Count - 1)
                targetIndex = 0;
            SetHorizontalTargetItemIndex(_items[targetIndex]);
        }

        // Click the left button the select next next item.
        public void OnBtnLeftClick()
        {
            if (!canChangeItem)
                return;
            int targetIndex = curCenterItem.CurveOffSetIndex - 1;
            if (targetIndex < 0)
                targetIndex = _items.Count - 1;
            SetHorizontalTargetItemIndex(_items[targetIndex]);
        }

        public float factor = 0.001f;
        // On Drag Move
        public void OnDragEnhanceViewMove(Vector2 delta)
        {
            // In developing
            if (Mathf.Abs(delta.x) > 0.0f)
            {
                curHorizontalValue += delta.x * factor;
                LerpTweenToTarget(0.0f, curHorizontalValue, false);
            }
        }

        // On Drag End
        public void OnDragEnhanceViewEnd()
        {
            // find closed item to be centered
            int closestIndex = 0;
            float value = (curHorizontalValue - (int)curHorizontalValue);
            float min = float.MaxValue;
            float tmp = 0.5f * (curHorizontalValue < 0 ? -1 : 1);
            for (int i = 0; i < _items.Count; i++)
            {
                float dis = Mathf.Abs(Mathf.Abs(value) - Mathf.Abs((tmp - _items[i].CenterOffSet)));
                if (dis < min)
                {
                    closestIndex = i;
                    min = dis;
                }
            }
            originHorizontalValue = curHorizontalValue;
            float target = ((int)curHorizontalValue + (tmp - _items[closestIndex].CenterOffSet));
            preCenterItem = curCenterItem;
            curCenterItem = _items[closestIndex];
            LerpTweenToTarget(originHorizontalValue, target, true);
            canChangeItem = false;
        }
    }
}