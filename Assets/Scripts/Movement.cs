using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private Rigidbody2D _playerRb;
    private Animator _animator;
    
    private Vector2 _move;
    void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        _move = new Vector2(Input.GetAxis("Horizontal"), 0);
        PlayerMovement();
        PlayerAttack();
        RightFacing();
    }

    private void PlayerAttack()
    {
        if(Input.GetKeyDown(KeyCode.S))
            _animator.SetTrigger("Attack");
    }

    private void PlayerMovement()
    {
        Vector2 moveVector = transform.TransformDirection(_move) * speed; //make freeze rotation
        _playerRb.velocity = new Vector2(moveVector.x, _playerRb.velocity.y);
        _animator.SetBool("IsRunning", _playerRb.velocity.x != 0);
    }
    private void RightFacing()
    { 
        if (Input.GetAxisRaw("Horizontal") > 0) 
            transform.localScale = new Vector3(1, 1, 1);
        else if (Input.GetAxisRaw("Horizontal") < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }
}