using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CharacterController))]
public class MovingAnObject : MonoBehaviour
{
    [SerializeField] private int _speed;

    private Rigidbody _rigidbody;
    private CharacterController _characterController;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Call method here with one type of movement
        // ...
    }

    private void MoveForward()
    {
        transform.position += Vector3.forward * _speed * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, new Vector3(1, 1, 1), 3);
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        _rigidbody.MovePosition(transform.position + Vector3.forward * _speed * Time.deltaTime);
        _characterController.Move(Vector3.forward * _speed * Time.deltaTime);
    }

    private void MoveSideways()
    {
        transform.position += (Vector3.forward + Vector3.right) * _speed * Time.deltaTime;
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector3.up * 200);
    }
}
