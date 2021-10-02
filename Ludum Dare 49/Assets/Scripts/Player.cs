using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Assets.Scripts;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    private ICommand _controller;
    public ICommand Controller
    {
        set { _controller = value; }
    }

    private bool _isJumping;
    public bool IsJumping
    {
        get { return _isJumping; }
        set { _isJumping = value; }
    }

    GameObject _player;

    private CollisionHandler _colHander;

    private float _health;
    public float Health
    {
        get { return _health; }
        set { _health = value; }
    }

    void Start()
    {
        _isJumping = false;
        _player = this.gameObject;
        _colHander = CollisionHandler.Instance;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _controller.Execute();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        _colHander.OnCollisonEnter(collision);
    }
}
