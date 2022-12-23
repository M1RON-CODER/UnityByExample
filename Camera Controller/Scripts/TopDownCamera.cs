using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    [SerializeField] private int _moveSpeed;

    private void Update()
    {
        Vector3 mouse = Input.mousePosition;
        if (mouse.x <= 0 || Input.GetKey(KeyCode.A))
        {
            Move(Vector3.left);
        }
        else if (mouse.x >= Screen.width || Input.GetKey(KeyCode.D))    
        { 
            Move(Vector3.right);
        }

        if (mouse.y <= 0 || Input.GetKey(KeyCode.S))
        {
            Move(Vector3.back);
        }
        else if(mouse.y >= Screen.height || Input.GetKey(KeyCode.W))
        {
            Move(Vector3.forward);
        }
    }

    private void Move(Vector3 position)
    {
        transform.Translate(position * _moveSpeed * Time.deltaTime);
    }
}
