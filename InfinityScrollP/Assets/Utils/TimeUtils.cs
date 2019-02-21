#region 注释
/*
*         Title: TimeUtils : TestProject
*         Description:
*                功能：  时间工具类
*         Author:           Herbie  
*         Version:          0.1版本
*         Modify Recoder: 
*/
#endregion

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Utils
{
    public class TimeUtils : MonoBehaviour
    {
        public static TimeUtils Time;
        // Timer objects
        private List<Timer> _timers;
        // Timer removal queue
        private List<int> _removalPending;
        private int _idCounter;

        /// <summary>
        /// Timer entity class
        /// </summary>
        public class Timer
        {
            public int _id;
            public bool _isActive;

            public float _rate;
            public int _ticks;
            public int _ticksElapsed;
            public float _last;
            public Action _callBack;

            public Timer(int id, float rate, int ticks, Action callback)
            {
                _id = id;
                this._rate = rate < 0 ? 0 : rate;
                this._ticks = ticks < 0 ? 0 : ticks;
                _callBack = callback;
                _last = 0;
                _ticksElapsed = 0;
                _isActive = true;
            }

            public void Tick()
            {
                _last += UnityEngine.Time.deltaTime;

                if (_isActive && _last >= _rate)
                {
                    _last = 0;
                    _ticksElapsed++;
                    _callBack.Invoke();

                    if (_ticks > 0 && _ticks == _ticksElapsed)
                    {
                        _isActive = false;
                        Time.RemoveTimer(_id);
                    }
                }
            }
        }

        /// <summary>
        /// Awake
        /// </summary>
        private void Awake()
        {
            Time = this;
            _timers = new List<Timer>();
            _removalPending = new List<int>();
        }

        /// <summary>
        /// Creates new timer
        /// </summary>
        /// <param name="rate">Tick rate</param>
        /// <param name="callBack">Callback method</param>
        /// <returns>Time GUID</returns>
        public int AddTimer(float rate, Action callBack)
        {
            return AddTimer(rate, 0, callBack);
        }

        /// <summary>
        /// Creates new timer
        /// </summary>
        /// <param name="rate">Tick rate</param>
        /// <param name="ticks">Number of ticks before timer removal</param>
        /// <param name="callBack">Callback method</param>
        /// <returns>Timer GUID</returns>
        public int AddTimer(float rate, int ticks, Action callBack)
        {
            Timer newTimer = new Timer(++_idCounter, rate, ticks, callBack);
            _timers.Add(newTimer);
            return newTimer._id;
        }

        /// <summary>
        /// Removes timer
        /// </summary>
        /// <param name="timerId">Timer GUID</param>
        public void RemoveTimer(int timerId)
        {
            _removalPending.Add(timerId);
        }

        /// <summary>
        /// Timer removal queue handler
        /// </summary>
        public void Remove()
        {
            if (_removalPending.Count > 0)
            {
                foreach (int id in _removalPending)
                    for (int i = 0; i < _timers.Count; i++)
                        if (_timers[i]._id == id)
                        {
                            _timers.RemoveAt(i);
                            break;
                        }

                _removalPending.Clear();
            }
        }

        /// <summary>
        /// Updates timers
        /// </summary>
        public void Tick()
        {
            for (int i = 0; i < _timers.Count; i++)
                _timers[i].Tick();
        }

        // Update is called once per frame
        private void Update()
        {
            Remove();
            Tick();
        }
    }
}