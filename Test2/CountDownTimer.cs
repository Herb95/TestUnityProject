using System;
using System.Collections;

namespace LianJian {
    public sealed class CountDownTimer {
        /// <summary>
        /// 是否自动循环
        /// </summary>
        public bool IsAutoCycle { get; private set; }
        /// <summary>
        /// 是否暂停
        /// </summary>
        public bool IsStoped { get; private set; }
        /// <summary>
        /// 当前时间
        /// </summary>
        // public float CurrentTime {
        //     get{return 0;}
        //     // get { return UpdateCurrentTime (); }
        // }
        /// <summary>
        /// 时间是否到
        // /// </summary>
        // public bool IsTimeUp {
        //     get { return CurrentTime <= 0; }
        // }
        /// <summary>
        /// 计时时间长度
        /// </summary>
        public float Duration { get; private set; }
        /// <summary>
        /// 上一次更新的时间
        /// </summary>
        // private float _lastTime;
        /// <summary>
        /// 上一次更新倒计时的帧数（避免一帧多次更新计时）
        /// </summary>
        // private int _lastUpdateFram;
        /// <summary>
        // 当前计时器剩余时间
        /// </summary>
        private float _currentTime;

        public CountDownTimer (float duration, bool autoCycle = false, bool autoStart = true) {
            IsStoped = true;
            Duration = Math.Max (0f, duration);
            IsAutoCycle = autoCycle;
            Rest (duration, !autoStart);
        }
        /*
                /// <summary>
                /// 更新计时器时间
                /// </summary>
                /// <returns></returns>
                private float UpdateCurrentTime () {
                    if (IsStoped || _lastUpdateFram == Time.frameCount)
                        return _currentTime;
                    if (_currentTime <= 0) {
                        if (IsAutoCycle) {
                            Rest (Duration, false);
                        }
                        return _currentTime;
                    }
                    _currentTime -= Time.time - _lastTime;
                    UpdateLastTimeInfo ();
                    return _currentTime;
                }

                /// <summary>
                /// 更新时间标记信息
                /// </summary>
                private void UpdateLastTimeInfo () {
                    _lastTime = Time.time;
                    _lastUpdateFram = Time.frameCount;
                }

        */
        public void Start () {
            Rest (Duration, false);
        }

        /// <summary>
        /// 重置倒计时
        /// </summary>
        /// <param name="duration">持续时间</param>
        /// <param name="isStop">是否暂停</param>
        private void Rest (float duration, bool isStop = false) {
            // UpdateLastTimeInfo ();
            Duration = Math.Max (0f, duration);
            _currentTime = Duration;
            IsStoped = isStop;
        }

        /// <summary>
        /// 暂停
        /// </summary>
        public void Pause () {
            //暂停前更新
            // UpdateCurrentTime ();
            IsStoped = true;
        }

        /// <summary>
        /// 继续
        /// </summary>
        public void Continue () {
            // UpdateLastTimeInfo ();
            IsStoped = false;
        }

        /// <summary>
        /// 终止,暂停切设置当前值为0
        /// </summary>
        public void End () {
            IsStoped = true;
            _currentTime = 0f;
        }

        /// <summary>
        /// 获取倒计时完成率(0没有开始,1位计时结束)
        /// </summary>
        /// <returns></returns>
        public float GetPercent () {
            // UpdateCurrentTime ();
            if (_currentTime <= 0 || Duration <= 0)
                return 1f;
            return 1f - _currentTime / Duration;
        }
    }
}