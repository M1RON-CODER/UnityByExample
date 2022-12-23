using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class FirstPersonCharacterController : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private int _lookSpeedMouse;
    [SerializeField] private int _moveSpeed;
    [SerializeField] private int _jumpHeight;
    [SerializeField] private float _sprint;
    [SerializeField] private float _gravity = 9.8f;

    private Vector2 _rotation;
    private CharacterController _characterController;
    private Animator _animator;
    private float _velocity = 0f;

    private void OnValidate()
    {
        _sprint = _moveSpeed >= _sprint ? _moveSpeed * 1.5f : _sprint;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        MouseLook();
        Move();
    }

    private void MouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * _lookSpeedMouse * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _lookSpeedMouse * Time.deltaTime;

        _rotation.y += mouseX;
        _rotation.x -= mouseY;

        _rotation.x = Mathf.Clamp(_rotation.x, -90, 90);

        _camera.transform.rotation = Quaternion.Euler(_rotation.x, _rotation.y, 0);
        transform.rotation = Quaternion.Euler(0, _rotation.y, 0);
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal") * _moveSpeed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime;

        if (_characterController.isGrounded)
        {
            _velocity = 0;
        }

        _velocity += Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded ? Mathf.Sqrt(_jumpHeight * _gravity) : -_gravity * Time.deltaTime;
        vertical *= Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) ? _sprint : _moveSpeed;

        _characterController.Move((_camera.transform.right * horizontal + transform.forward * vertical + new Vector3(0, _velocity, 0)) * Time.deltaTime);
 
        AnimationChange(vertical);
    }

    private void AnimationChange(float v)
    {
        bool isWalking = v > 0 ? true : false;
        bool isRunning = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) ? true : false;
        bool isJumping = Input.GetKey(KeyCode.Space) && v == 0 ? true : false;
        
        _animator.SetBool(Key.Animation.Walking.ToString(), isWalking);
        _animator.SetBool(Key.Animation.Running.ToString(), isRunning);
        _animator.SetBool(Key.Animation.Jumping.ToString(), isJumping);
    }
}
