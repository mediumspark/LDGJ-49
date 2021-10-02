using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Assets.Scripts
{
    public class Timer
    {
        public delegate void TimerExpired();
        public event TimerExpired Expired;

        private int _secs;
        public int Secs
        {
            get { return _secs; }
 
        }

        bool _enabled;

        private IObserver _tickObserver;

        public Timer(int secs, TimerExpired callback, IObserver tickObserver)
        {
            _secs = secs;
            Expired += callback;
            _enabled = false;
            _tickObserver = tickObserver;
        }

        public void Start()
        {
            _enabled = true;
        }

        public void Stop()
        {
            _enabled = false;
        }

        public void DecrementTimer()
        {
            if (_enabled)
            {
                _secs--;
                _tickObserver.SendCallbacks();
                if (_secs < 1)
                {
                    TimerDidExpire();
                    _enabled = false;
                }
            }
        }

        private void TimerDidExpire()
        {
            Expired();
        }
    }
}
