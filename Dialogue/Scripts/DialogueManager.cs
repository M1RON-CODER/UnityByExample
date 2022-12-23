using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _title;
    [SerializeField] private TMP_Text _dialogue;
    [SerializeField] private List<Dialogue> _dialogues = new();

    private int _nameIndex;
    private int _dialogIndex;

    private void Start()
    {
        StartDialog();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextDialog();
        }
    }

    public void StartDialog()
    {
        DisplayDialog();
    }

    private void DisplayDialog()
    {
        _title.text = _dialogues[_nameIndex].Name;
        _dialogue.text = _dialogues[_nameIndex].Dialogues[_dialogIndex];
    }

    private void NextDialog()
    {
        if (_dialogIndex != _dialogues[_nameIndex].Dialogues.Count - 1)
        {
            _dialogIndex++;
        }
        else
        {
            if (_nameIndex == _dialogues.Count - 1)
            {
                Debug.Log("Dialog end");
                return;
            }

            _nameIndex++;
            _dialogIndex = 0;
        }

        DisplayDialog();
    }
}
