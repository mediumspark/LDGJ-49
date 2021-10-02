using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOperationalDirector : MonoBehaviour
{
    // Start is called before the first frame update
    private Player _player;
    private UIMananger _ui;
    private CameraController cameraController;
    private GameObject mainCam;
    private IEnumerator routine;
    private IHasText _focusedDialogCharacter;
    void Start()
    {

        mainCam = GameObject.Find("Main Camera");
        if (SceneManager.GetActiveScene().name.ToLower() == "title")
        {
            DontDestroyOnLoad(GameObject.Find("Music"));
            SoundManager.Instance.Play("fire");
        }
        else if(SceneManager.GetActiveScene().name.ToLower() == "story")
        {
            GameObject story = GameObject.Find("Main Camera");
            GameObject.Find("Main Camera").GetComponent<Story>().SetController(ControllerFactory.CreateController(story));
            SoundManager.Instance.Stop();
            _focusedDialogCharacter = GameObject.Find("Main Camera").GetComponent<Story>();
        }

        else
        {
            _ui = new UIMananger();
            _player = GameObject.Find("Player").GetComponent<Player>();
            _player.Controller = ControllerFactory.CreateController(GameObject.FindGameObjectWithTag("Player"));



            SoundManager.Instance.Play("normal");
           //Will need to change this to take loaded scene as a parameter.
            cameraController = new CameraController(mainCam, GameObject.Find("Player"));
            StartCoroutine(Timer(100));
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      if(cameraController != null)
        {
            cameraController.PositionCamera();
        }
    }


    public void PlayClicked()
    {
        SceneManager.LoadScene("Story");
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

    public void ScrollDialog()
    {
        _focusedDialogCharacter.ScrollText();
    }
   /** public void TransitionCamera()
    {
        SettingsRegistry.Instance.PanEnabled = false;
        if(cameraController != null)
        {
            StartCoroutine(cameraController.Transition());
        } 
    }
    **/
}
