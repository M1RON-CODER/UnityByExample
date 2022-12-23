using System.Collections.Generic;
using UnityEngine;

public class Construction : MonoBehaviour
{
    [SerializeField] private Building _building;
    [SerializeField] private List<Building> _buildings = new();

    private void Start()
    {
        Build();
        LoadBuildings();
    }

    private void LoadBuildings()
    {
        Storage.Load(ref _building);
        Storage.Load(_buildings);
    }

    private void Build()
    {
        // do something...

        Storage.Save(_building);
        Storage.Save(_buildings);
    }
}
