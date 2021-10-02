using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using System;
using UnityEngine;

public class GameOperationalDirector : MonoBehaviour
{
    // Start is called before the first frame update
    private Player _player;
    private UIMananger _ui;
    private CameraController cameraController;
    private GameObject mainCam;
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _player.Controller = ControllerFactory.CreateController(GameObject.FindGameObjectWithTag("Player"));

        mainCam = GameObject.Find("Main Camera");
        DontDestroyOnLoad(GameObject.Find("Music"));
        SoundManager.Instance.Play("normal");
        _ui = new UIMananger(); //Will need to change this to take loaded scene as a parameter.
        cameraController = new CameraController(mainCam, GameObject.Find("Player"));
        StartCoroutine(Timer(100));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      if(cameraController != null)
        {
            cameraController.PositionCamera();
        }
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

    public void TransitionCamera()
    {
        cameraController.BeginTransition();
        if(cameraController != null)
        {
            StartCoroutine(cameraController.Transition());
        } 
    }
    
}
