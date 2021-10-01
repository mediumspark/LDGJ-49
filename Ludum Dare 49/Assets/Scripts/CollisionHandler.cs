using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class CollisionHandler
    {
        private static CollisionHandler _instance;
        public static CollisionHandler Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new CollisionHandler();
                }
                return _instance;
            }
        }

        private Player _player;


        private CollisionHandler()
        {
            _player = GameObject.Find("Player").GetComponent<Player>();
        }

        public void OnCollisonEnter(Collision col)
        {
            GameObject obj = col.gameObject;
            if(obj.tag.ToLower() == "ground")
            {
                _player.IsJumping = false;
            }
        }
    }
}
