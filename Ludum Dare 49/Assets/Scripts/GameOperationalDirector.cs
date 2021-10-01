using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class GameOperationalDirector : MonoBehaviour
{
    // Start is called before the first frame update
    Player _player;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _player.Controller = ControllerFactory.CreateController(GameObject.FindGameObjectWithTag("Player"));
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
