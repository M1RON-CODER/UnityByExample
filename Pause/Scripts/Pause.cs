using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private RectTransform _pause;
    [SerializeField] private KeyCode _key = KeyCode.Escape;
    private bool _isPause;

    private void Update()
    {
        if (Input.GetKeyDown(_key))
        {
            Time.timeScale = _isPause ? 1.0f : 0.0f;
            _isPause = !_isPause;
            _pause.gameObject.SetActive(!_pause.gameObject.activeSelf);
        }
    }
}
