using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class ControllerFactory
    {
        public static ICommand CreateController(GameObject player)
        {
            switch(Application.platform)
            {
                case RuntimePlatform.WindowsEditor: return new KeyboardController(player); 
                case RuntimePlatform.OSXEditor: return new KeyboardController(player); 
                case RuntimePlatform.OSXPlayer: return new KeyboardController(player);
                case RuntimePlatform.WindowsPlayer: return new KeyboardController(player);
                default: return new BlankController() ;
            }
        }
    }
}
