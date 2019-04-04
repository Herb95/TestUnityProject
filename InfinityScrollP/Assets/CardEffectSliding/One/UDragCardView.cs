#region 注释
/*
 *         Title: UDragCardView : #rootnamespace#
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
using UnityEngine.EventSystems;

namespace Assets.CardEffectSliding.One
{
    public class UDragCardView : EventTrigger
    {
        private CardEffectSliding enhanceScrollView;

        public void SetScrollView(CardEffectSliding view)
        {
            enhanceScrollView = view;
        }

        public override void OnBeginDrag(PointerEventData eventData)
        {
            base.OnBeginDrag(eventData);
        }

        public override void OnDrag(PointerEventData eventData)
        {
            base.OnDrag(eventData);
            if (enhanceScrollView != null)
                enhanceScrollView.OnDragEnhanceViewMove(eventData.delta);
        }

        public override void OnEndDrag(PointerEventData eventData)
        {
            base.OnEndDrag(eventData);
            if (enhanceScrollView != null)
                enhanceScrollView.OnDragEnhanceViewEnd();
        }
    }
}