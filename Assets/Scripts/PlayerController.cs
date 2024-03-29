using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _fallVelocity = 0;
    private float _gravity = 10;
    private Vector3 _moveVector;

    public float jumpForce;
    public float speed;

    private CharacterController _characterController;
    public Animator playerAnimationController;
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        _moveVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
        }








        if (Input.GetKeyDown(KeyCode.Space)&&_characterController.isGrounded)
        {
            _fallVelocity = -jumpForce;
        }

        AnimationControllerUpdate();
    }

    // Update is called once per frame
    void FixedUpdate()
    {  
        _characterController.Move(_moveVector * speed * Time.deltaTime);
        _fallVelocity += _gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * Time.fixedDeltaTime * _fallVelocity);

        if( _characterController.isGrounded )
        {
            _fallVelocity = 0;
        }
    }

    private void AnimationControllerUpdate()
    {
        if ( _moveVector == Vector3.zero)
            {
            playerAnimationController.SetInteger("animator value", 0);
            }
        else
        {
            playerAnimationController.SetInteger("animator value", 1);
        }
        if (Input.GetMouseButtonDown(0))
        {
            playerAnimationController.SetInteger("animator value", 2);
        }
    }
}
