using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class EnableDisableComponent : MonoBehaviour
{
    private BoxCollider _collider;

    private void Start()
    {
        _collider = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _collider.enabled = !_collider.enabled;
        }
    }
}
