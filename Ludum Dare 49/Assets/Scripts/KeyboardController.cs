using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class KeyboardController : ICommand
{
    private GameObject _player;
    public GameObject Player
    {
        get {return _player;}
    }

    /// <summary>
    /// Controller object must take a reference of the player
    /// </summary>
    /// <param name="player"></param>
    public KeyboardController(GameObject player)
    {
        if(player == null)
        {
            throw new ArgumentException("The player cannot be null");
        }
        _player = player;
    }

    public void Execute()
    {
        float jumpForce = 250f;
        float moveStep = 4.0f;
        Rigidbody2D rigidbody = _player.GetComponent<Rigidbody2D>();
        Player player = _player.GetComponent<Player>();
        if((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)) && !player.IsJumping)
        {
            rigidbody.AddForce(new Vector2(0, jumpForce)); //This is an obvious place holder
            player.IsJumping = true;
        }
        
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody.transform.position -= new Vector3(moveStep * Time.deltaTime, 0, 0);
            if (!_player.GetComponent<Player>().FacingLeft)
            {
                _player.transform.rotation = new Quaternion(0, 180, 0, 0);
                _player.GetComponent<Player>().FacingLeft = true;
               GameObject.Find("Main Camera").GetComponent<GameOperationalDirector>().TransitionCamera();

            }
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody.transform.position += new Vector3(moveStep * Time.deltaTime, 0, 0);
            if (_player.GetComponent<Player>().FacingLeft)
            { 
                player.transform.rotation = new Quaternion(0, 0, 0, 0);
                _player.GetComponent<Player>().FacingLeft = false;
               GameObject.Find("Main Camera").GetComponent<GameOperationalDirector>().TransitionCamera();
            }

        }
        
    }




}
