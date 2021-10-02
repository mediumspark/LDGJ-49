using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class SettingsRegistry
    {

        private object _lockObj;

        private static SettingsRegistry _instance;
        public static SettingsRegistry Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SettingsRegistry();
                }
                return _instance;
            }
        }

        public CameraAngles CamAngle
        {
            get;
            set;
        }

        public bool TransitionCamera
        {
            get;
            set;
        }

        private float _offset;
        public float Offset
        {
            get
            {
                lock(_lockObj)
                {
                    return _offset;
                }
            }

            set
            {
                lock (_lockObj)
                {
                    _offset = value;
                }
            }
        }

        public  const int OFFSETFLAG = -30;

        public bool PanEnabled
        {
            get;
            set;
        }

        public bool DialogControls
        {
            get;
            set;
        }

        public bool ControlsEnabled
        {
            get;
            set;
        }

        private SettingsRegistry() { 
            _lockObj = new object(); _offset = SettingsRegistry.OFFSETFLAG; PanEnabled = true;
            DialogControls = false;
        }
    }
}
