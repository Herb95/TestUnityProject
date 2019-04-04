#region 注释
/*
 *         Title: CardEffectSliding : TestUnity
 *         Description:
 *                功能：      卡牌滑动循环列表
 *         Author:            Herbie  
 *         Time:              #time#
 *         Version:           0.1版本
 *         Modify Recoder:
 *         Url; (ScrollRect效果)[https://blog.csdn.net/AGroupOfRuffian/article/details/78910000]
*/
#endregion

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.CardEffectSliding.One
{
    public class CardEffectSliding : MonoBehaviour
    {
        // 缩放曲线
        public AnimationCurve scaleCurve;
        // 位移曲线
        public AnimationCurve postCure;
        //深度曲线
        public AnimationCurve depthCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
        //开始中心下标
        [Tooltip("The Start center index")]
        public int startCenterIndex = 0;
        //Item之间的偏移宽度
        public float cellWidht = 10f;
        private float totalHorizontalWidth = 500.0f;
        //垂直固定位置值
        public float yFxiedPositionValue = 46.0f;

        //差值持续时间
        public float lerpDurationValue = 0.2f;
        private float mCurrentDuration = 0.0f;
        private int mCenterIndex = 0;
        public bool enableLerpTween = true;


        private CardItem curCenterItem;
        private CardItem preCenterItem;

        /// <summary>
        /// 当前处于移动中,不能进行点击切换
        /// </summary>
        private bool canChangeItem = true;
        private float dFactor = 0.2f;

        /// <summary>
        /// 原始水平值Lerp到水平目标值
        /// </summary>
        private float originHorizontalValue = 0.1f;
        public float curHorizontalValue = 0.5f;

        //"depth" factor (2d widget depth or 3d Z value)
        private int depthFactor = 5;
        public float factor = 0.001f;

        public List<CardItem> _items;
        private List<CardItem> listSortedItems = new List<CardItem>();

        private Button _leftBtn;
        private Button _rightBtn;

        private static CardEffectSliding _instance;
        public static CardEffectSliding GetInstance()
        {
            return _instance;
        }

        private void Awake()
        {
            _instance = this;
            _leftBtn = GameObject.Find("LeftBtn").GetComponent<Button>();
            _rightBtn = GameObject.Find("RightBtn").GetComponent<Button>();
        }

        private void OnEnable()
        {
            _items = new List<CardItem>(CardUtils.Instance.CreateItems(this.transform, 8).ToArray());

            _leftBtn.onClick.AddListener(OnBtnLeftClick);
            _rightBtn.onClick.AddListener(OnBtnRightClick);
        }

        private void Start()
        {
            InitScrollRect();
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitScrollRect()
        {
            canChangeItem = true;
            int count = _items.Count;
            dFactor =(Mathf.RoundToInt((1f / count) * 10000f)) * 0.0001f;
            mCenterIndex = count / 2;
            if (count % 2 == 0)
                mCenterIndex = count / 2 - 1;
            int index = 0;
            for (int i = count - 1; i >= 0; i--)
            {
                _items[i].CurveOffSetIndex = i;
                _items[i].CenterOffset = dFactor * (mCenterIndex - index);
                _items[i].SetSelectColor(false);

                GameObject obj = _items[i].gameObject;
                UDragCardView script = obj.GetComponent<UDragCardView>();
                if (script != null)
                    script.SetScrollView(this);

                index++;
            }

            if (startCenterIndex < 0 || startCenterIndex >= count)
            {
                Debug.LogError("## startCenterIndex < 0 || startCenterIndex >= _items.Count  out of index ##");
                startCenterIndex = mCenterIndex;
            }

            listSortedItems = new List<CardItem>(_items.ToArray());
            totalHorizontalWidth = cellWidht * count;
            curCenterItem = _items[startCenterIndex];
            curHorizontalValue = 0.5f - curCenterItem.CenterOffset;
            LerpTweenToTarget(0f, curHorizontalValue, false);
        }

        private void LerpTweenToTarget(float originValue, float targetValue, bool needTween = false)
        {
            if (!needTween)
            {
                SortItemDepth();
                originHorizontalValue = targetValue;
                UpdateScrollView(targetValue);
                OnTweenOver();
            }
            else
            {
                originHorizontalValue = originValue;
                curHorizontalValue = targetValue;
                mCurrentDuration = 0.0f;
            }
            enableLerpTween = needTween;
        }

        public void UpdateScrollView(float fValue)
        {
            for (int i = 0; i < _items.Count; i++)
            {
                CardItem item = _items[i];
                float xValue = GetXPosValue(fValue, item.CenterOffset);
                float scaleValue = GetScaleValue(fValue, item.CenterOffset);
                float depthCurveValue = depthCurve.Evaluate(fValue + item.CenterOffset);
                item.UpdateScrollViewItems(
                    xValue,
                    depthCurveValue, 
                    depthFactor, 
                    _items.Count,
                    yFxiedPositionValue,
                    scaleValue);
            }
        }

        /// <summary>
        /// 缩放曲线模拟当前缩放值
        /// </summary>
        /// <param name="sliderValue"></param>
        /// <param name="added"></param>
        /// <returns></returns>
        private float GetScaleValue(float sliderValue, float added)
        {
            float scaleValue = scaleCurve.Evaluate(sliderValue + added);
            return scaleValue;
        }

        /// <summary>
        /// 位置曲线模拟当前x轴的位置
        /// </summary>
        /// <param name="sliderValue"></param>
        /// <param name="added"></param>
        /// <returns></returns>
        private float GetXPosValue(float sliderValue, float added)
        {
            float evaluetalValue = postCure.Evaluate(sliderValue + added) * totalHorizontalWidth;
            return evaluetalValue;
        }
        public static int SortPosition(CardItem a, CardItem b)
        {
            return a.transform.localPosition.x.CompareTo(b.transform.localPosition.x);
        }
        private void SortItemDepth()
        {
            listSortedItems.Sort(SortPosition);
            for (int i = listSortedItems.Count - 1; i >= 0; i--)
            {
                listSortedItems[i].RealIndex = i;
            }
        }


        private void Update()
        {
            if (enableLerpTween)
                TweenViewToTarget();
        }

        private void TweenViewToTarget()
        {
            mCurrentDuration += Time.deltaTime;
            if (mCurrentDuration > lerpDurationValue)
                mCurrentDuration = lerpDurationValue;

            float percent = mCurrentDuration / lerpDurationValue;
            float value = Mathf.Lerp(originHorizontalValue, curHorizontalValue, percent);
            UpdateScrollView(value);
            if (mCurrentDuration >= lerpDurationValue)
            {
                canChangeItem = true;
                enableLerpTween = false;
                OnTweenOver();
            }
        }

        private void OnTweenOver()
        {
            if (preCenterItem != null)
                preCenterItem.SetSelectColor(false);
            if (curCenterItem != null)
                curCenterItem.SetSelectColor(true);
        }

        /// <summary>
        /// 获取当前要移动到中心的Itme 需要移动的factor间隔数
        /// </summary>
        /// <param name="targeXPos"></param>
        /// <returns></returns>
        private int GetMoveCureFactorCount(CardItem preCenterItem, CardItem newCenterItem)
        {
            SortItemDepth();
            int factorCount = Mathf.Abs(newCenterItem.RealIndex) - Mathf.Abs(preCenterItem.RealIndex);
            return Mathf.Abs(factorCount);
        }


        public void SetHorizontalTargetItemIndex(CardItem selectItem)
        {
            if (!canChangeItem)
                return;
            if (curCenterItem == selectItem)
                return;

            canChangeItem = false;
            preCenterItem = curCenterItem;
            curCenterItem = selectItem;

            //计算移动的方向
            float centerXValue = postCure.Evaluate(0.5f) * totalHorizontalWidth;

            bool isRight = selectItem.transform.localPosition.x > centerXValue;

            //计算 offset* dFactor
            int moveIndexCount = GetMoveCureFactorCount(preCenterItem, selectItem);
            float dValue = 0.0f;
            //更改targe数值  平滑移动
            float originValue = curHorizontalValue;

            if (isRight)
            {
                dValue = -dFactor * moveIndexCount;
            }
            else
            {
                dValue = dFactor * moveIndexCount;
            }
            LerpTweenToTarget(originValue, (curHorizontalValue + dValue), true);
        }

        /// <summary>
        /// 向左选择角色按钮
        /// </summary>
        public void OnBtnLeftClick()
        {
            if (!canChangeItem)
                return;
            int targetIndex = curCenterItem.CurveOffSetIndex - 1;
            if (targetIndex < 0)
            {
                targetIndex = _items.Count - 1;
            }
            SetHorizontalTargetItemIndex(_items[targetIndex]);
        }
        /// <summary>
        /// 向右选择角色按钮
        /// </summary>
        public void OnBtnRightClick()
        {
            if (!canChangeItem)
                return;
            int targetIndex = curCenterItem.CurveOffSetIndex + 1;
            if (targetIndex > _items.Count - 1)
                targetIndex = 0;
            SetHorizontalTargetItemIndex(_items[targetIndex]);
        }

        /// <summary>
        /// 拖动状态
        /// </summary>
        /// <param name="delta"></param>
        public void OnDragEnhanceViewMove(Vector2 delta)
        {
            // In developing
            if (Mathf.Abs(delta.x) > 0.0f)
            {
                curHorizontalValue += delta.x * factor;
                LerpTweenToTarget(0.0f, curHorizontalValue, false);
            }
        }

        /// <summary>
        /// 拖动结束
        /// </summary>
        public void OnDragEnhanceViewEnd()
        {
            int closestIndex = 0;
            float value = (curHorizontalValue - (int)curHorizontalValue);
            float min = float.MaxValue;
            float tmp = 0.5f * (curHorizontalValue < 0 ? -1 : 1);
            for (int i = 0; i < _items.Count; i++)
            {
                float dis = Mathf.Abs(Mathf.Abs(value) - Mathf.Abs((tmp - _items[i].CenterOffset)));
                if (dis < min)
                {
                    closestIndex = i;
                    min = dis;
                }
            }
            originHorizontalValue = curHorizontalValue;
            float target = ((int)curHorizontalValue + (tmp - _items[closestIndex].CenterOffset));
            preCenterItem = curCenterItem;
            curCenterItem = _items[closestIndex];
            LerpTweenToTarget(originHorizontalValue, target, true);
            canChangeItem = false;
        }
    }
}