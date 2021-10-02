using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    /// <summary>
    /// Used for timer callbacks 
    /// </summary>
    public class TimerObserver : IObserver
    {
        private Callback _callback;

        public TimerObserver() { }
        /// <summary>
        /// Creates an instance of the Timer observer with the specified callback
        /// </summary>
        /// <param name="callback"></param>
        public TimerObserver(Callback callback)
        {
            _callback += callback;
        }

        /// <summary>
        /// This method adds a callback
        /// </summary>
        /// <param name="c">the callback to add.</param>
        public void AddCallback(Callback c)
        {
            _callback += c;
        }

        /// <summary>
        /// This method will remove a funcion from the call back list
        /// </summary>
        /// <param name="c">the method to remove</param>
        public void RemoveCallback(Callback c)
        {
            _callback += c;
        }

        /// <summary>
        /// This method sends the call backs
        /// </summary>
        public void SendCallbacks()
        {
            _callback();
        }
    }
}
