using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class SoundManager
    {
        private Dictionary<string, AudioClip> _sound;


        private AudioSource _source;

        private static SoundManager _instance;

        public static SoundManager Instance
        {
            get 
            {
                if(_instance == null)
                {
                    _instance = new SoundManager();
                }
                return _instance;
            }
        }

        private SoundManager()
        {
            _sound = new Dictionary<string, AudioClip>();
            try
            {
                _source = GameObject.Find("Music").GetComponent<AudioSource>();
                LoadMusic();
            }
            catch(Exception e)
            {
                Debug.LogError($"An error occurred. Details:\n{e.Message}");
            }
        }

     
        private void LoadMusic()
        {
            _sound["song1"] =Resources.Load<AudioClip>(@"Music\song1");
            _sound["title"] = Resources.Load<AudioClip>(@"Music\fire");
        }

        public void Stop()
        {
            _source.Stop();
        }

        public void Play(string level)
        {
            _source.Stop();
            if(level == "normal")
            {
                _source.clip = _sound["song1"];
                _source.loop = true;
                _source.Play();
            }
            else
            {
                _source.clip = _sound["title"];
                _source.loop = true;
                _source.Play();
            }
        }
    }
}
