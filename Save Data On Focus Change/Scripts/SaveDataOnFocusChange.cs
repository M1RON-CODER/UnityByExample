using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataOnFocusChange : MonoBehaviour
{
    private void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus)
        {
            // Сохранение данных
            SaveData();
        }
    }

    private void SaveData()
    {
        // Код сохранения данных
        Debug.Log("Сохранение данных");
    }
}
