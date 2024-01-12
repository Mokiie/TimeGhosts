using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    private Vector2 _input;
    private CharacterController _characterController;
    private Vector3 _direction;
    private float _currentVelocity;
    [SerializeField] private float smoothTime = 0.05f;
    [SerializeField] private float speed;
    public Transform cam;
    private float gravity = -9.81f;
    [SerializeField] private float gravityMultiplier = 3.0f;
    private float velocity;
    Vector3 moveDirection;
    [SerializeField] private float jumpPower;
    public Ghost ghost;
    public GameObject spawnPoint;
    public GameObject ghostPlayer;
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        ghost.ResetData();
        ghost.isRecord = true;
        ghost.isReplay = false;
        
        
    }
    

    private void Update()
    {
        ApplyGravity();
        ApplyRotation();
        ApplyMovement();


        if (Input.GetKey("k"))
        {
            transform.position = spawnPoint.transform.position;
            //transform.rotation = spawnPoint.transform.rotation;
           
          
            ghost.isRecord = false;
            ghost.isReplay = true;
            ghostPlayer.SetActive(true);
        }
    }

    private void ApplyGravity() 
    {
        if (IsGrounded() && velocity < 0.0f)
        {
            velocity = -1.0f;
        }
        else 
        {
            velocity += gravity * gravityMultiplier * Time.deltaTime;
        }
        moveDirection.y = velocity;
    }

    private void ApplyRotation()
    {
        if (_input.sqrMagnitude == 0) return;
        var targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
        moveDirection = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;
    }

    private void ApplyMovement() 
    {

        if (_input == Vector2.zero)
        {
            moveDirection = new Vector3(0, moveDirection.y, 0);
        }
        _characterController.Move(moveDirection * speed * Time.deltaTime);
    }

    public void Move(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();
        _direction = new Vector3(_input.x, 0.0f, _input.y);
        Debug.Log(_input);

    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started) return;
        if (!IsGrounded()) return;

        velocity += jumpPower;
    }
    private bool IsGrounded() => _characterController.isGrounded;



}
