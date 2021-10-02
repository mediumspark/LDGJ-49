using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using System;
using UnityEngine;

public class GameOperationalDirector : MonoBehaviour
{
    // Start is called before the first frame update
    Player _player;
    UIMananger _ui;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _player.Controller = ControllerFactory.CreateController(GameObject.FindGameObjectWithTag("Player"));
        DontDestroyOnLoad(GameObject.Find("Music"));
        SoundManager.Instance.Play("normal");
        _ui = new UIMananger(); //Will need to change this to take loaded scene as a parameter.
        StartCoroutine(Timer(100));
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private IEnumerator Timer(int secs)
    {
        IObserver timeObs = new TimerObserver();
        Timer t = new Timer(secs, TimerExpired, timeObs);
        timeObs.RemoveCallback(() => _ui.UpdateTimer(t));
        while(t.Secs > 0)
        {
            t.Start();
            t.DecrementTimer();
            yield return new WaitForSeconds(1f);
        }
    }

    private void TimerExpired()
    {
        throw new NotImplementedException("Timer Expired");
    }
    
}
