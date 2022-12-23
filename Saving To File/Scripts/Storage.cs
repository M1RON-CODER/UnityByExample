using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Storage : MonoBehaviour
{
    private const string _buildFileName = "Build.json";
    private const string _buildsFileName = "Builds.json";

    public static void Save(Building building)
    {
        string json = JsonConvert.SerializeObject(building, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        File.WriteAllText($"{Application.persistentDataPath}/{_buildFileName}", json);
    }

    public static void Save(List<Building> buildings)
    {
        string json = JsonConvert.SerializeObject(buildings, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        File.WriteAllText($"{Application.persistentDataPath}/{_buildsFileName}", json);
    }

    public static void Load(ref Building building)
    {
        string file = $"{Application.persistentDataPath}/{_buildFileName}";
        if (ValidateFile(file))
        {
            building = JsonConvert.DeserializeObject<Building>(File.ReadAllText(file));
        }
    }

    public static void Load(List<Building> buildings)
    {
        string file = $"{Application.persistentDataPath}/{_buildsFileName}";
        if (ValidateFile(file))
        {
            buildings = JsonConvert.DeserializeObject<List<Building>>(File.ReadAllText(file));
        }
    }

    private static bool ValidateFile(string file)
    {
        if (!File.Exists(file))
        {
            Debug.Log("File Not Found");
            return false;
        }

        return true;
    }
}
