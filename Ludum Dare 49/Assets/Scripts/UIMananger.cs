using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class UIMananger
    {
        private TextMesh _lblTimer;

        public UIMananger()
        {
            _lblTimer = GameObject.Find("lblTimer").GetComponent<TextMesh>();
        }

        public void UpdateTimer(Timer t)
        {
            _lblTimer.text = $"Time: {t.Secs}";
        }
    }
}
