using UnityEngine;

public class Delay : MonoBehaviour
{
    [SerializeField] private int _delay;

    private void Start()
    {
        Debug.Log("Start");
        Invoke(nameof(SayHello), _delay);
    }

    private void SayHello()
    {
        Debug.Log("Hello!");
    }
}
