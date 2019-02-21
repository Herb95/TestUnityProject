#region 注释
/*
*         Title: IViewTipsState : LianJian
*         Description:
*                功能：***
*         Author:           Herbie  
*         Version:          0.1版本
*         Modify Recoder: 
*/
#endregion

namespace Assets.DesignPatterns.StateDesign1
{
    public class ViewTipsController
    {
        private IViewTipsState _state;
        private bool _isActive = false;

        public ViewTipsController() { }

        public void SetState(IViewTipsState state)
        {
            _isActive = false;
            //关闭之前界面
            if (_state != null)
                _state.StateEnd();
            _state = state;
        }

        public void StateUpdate()
        {
            if (_state != null && _isActive == false)
            {
                _state.StateBegin();
                _isActive = true;
            }
            if (_state != null)
                _state.StateUpdate();
        }
    }
}
