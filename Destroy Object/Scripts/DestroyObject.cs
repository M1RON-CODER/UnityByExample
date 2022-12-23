using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private void DestroyGameObject()
    {
        Destroy(gameObject); // Kill object on method call
    }

    private void DestroyComponent()
    {
        Destroy(GetComponent<Collider>()); // Remove collider from the game object
    }

    private void DestroyDelay()
    {
        Destroy(gameObject, 3f); // Kill object after 3 seconds
    }
    private void DestroyScript()
    {
        Destroy(this); // Remove script from the game object
    }
}
