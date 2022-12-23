using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    
    public void Initialize(string name)
    {
        _name.text = name;  
    }

    public void ChangeName(string name)
    {
        _name.text = name;
        _name.color = Color.green;
    }

    public void Revival()
    {
        gameObject.SetActive(true);
    }

    public void Death()
    {   
        gameObject.SetActive(false);
    }
}
