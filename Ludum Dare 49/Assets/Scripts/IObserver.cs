using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public delegate void Callback();
    public interface IObserver
    {
        void AddCallback(Callback c);
        void RemoveCallback(Callback c);
        void SendCallbacks();
    }
}
