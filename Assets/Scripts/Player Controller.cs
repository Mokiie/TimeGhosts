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
    public Timer timer;



    //Ghosts
    // public Ghost ghost;
    public GameObject spawnPoint;
    public List<GameObject> ghostPlayers;
    GhostRecorder gr;




    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();

        gr = GetComponent<GhostRecorder>();
        
       
    }


    private void Update()
    {
        ApplyGravity();
        ApplyRotation();
        ApplyMovement();

        if (Input.GetKeyDown("k"))
        {
            Die();
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            Die();
        }
    }

    void Die()
    {
        timer.time = 0;
        _characterController.enabled = false;
        transform.position = spawnPoint.transform.position;
        _characterController.enabled = true;
        //transform.rotation = spawnPoint.transform.rotation;

        gr.timer = 0;
        gr.timeValue = 0;
        gr.ghostList[gr.ghostIndex].isReplay = true;
        gr.ghostList[gr.ghostIndex].isRecord = false;
        ghostPlayers[gr.ghostIndex].SetActive(true);

        gr.ghostIndex++;

        if (gr.ghostIndex >= 10)
        {
            gr.ghostIndex = 0;
        }

        gr.ghostList[gr.ghostIndex].isReplay = false;
        gr.ghostList[gr.ghostIndex].isRecord = true;

        //Reset all ghosts to start time
        foreach (GameObject gp in ghostPlayers)
        {
            gp.GetComponent<GhostPlayer>().timeValue = 0;
        }
    }
}
