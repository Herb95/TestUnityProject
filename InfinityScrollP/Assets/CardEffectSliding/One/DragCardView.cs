#region 注释
/*
 *         Title: DragCardView : #rootnamespace#
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
using UnityEngine;

namespace Assets.CardEffectSliding.One
{
    public class DragCardView : MonoBehaviour
    {
        private CardEffectSliding enhanceScrollView;
        public void SetScrollView(CardEffectSliding view)
        {
            enhanceScrollView = view;
        }

        void OnEnhanceViewDrag(Vector2 delta)
        {
            if (enhanceScrollView != null)
                enhanceScrollView.OnDragEnhanceViewMove(delta);
        }

        void OnEnhaneViewDragEnd()
        {
            if (enhanceScrollView != null)
                enhanceScrollView.OnDragEnhanceViewEnd();
        }
    }
}