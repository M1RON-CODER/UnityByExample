using UnityEngine;

public class AroundCamera : MonoBehaviour
{
    [SerializeField] private int _lookSpeedMouse;
    [SerializeField] private Transform _target;

    private Vector2 _rotation;
    private float _distanceFromTarget = 3.5f;

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _lookSpeedMouse * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _lookSpeedMouse * Time.deltaTime;

        _rotation.y += mouseX;
        _rotation.x -= mouseY;
        _rotation.x = Mathf.Clamp(_rotation.x, -90, 90);

        _distanceFromTarget -= Input.mouseScrollDelta.y;

        transform.localEulerAngles = new Vector3(_rotation.x, _rotation.y, 0);
        transform.position = _target.position - transform.forward * _distanceFromTarget;
    }
}
