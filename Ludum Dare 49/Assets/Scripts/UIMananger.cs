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
        private TextMesh _lblHealth;

        public UIMananger()
        {
            _lblTimer = GameObject.Find("lblTimer").GetComponent<TextMesh>();
        }

        public void UpdateTimer(Timer t)
        {
            _lblTimer.text = $"Time: {t.Secs}";
        }

        public void UpdateHealth(Player p)
        {
            _lblHealth.text = $"Health: {p.Health}%";
            
            if(p.Health >= 51)
            {
                _lblHealth.color = Color.green;
            }
            else if(p.Health < 50)
            {
                _lblHealth.color = Color.yellow;
            }
            else
            {
                _lblHealth.color = Color.red;
            }
        }
    }
}
