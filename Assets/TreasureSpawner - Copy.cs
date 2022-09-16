using System.Collections.Generic;
using UnityEngine;

public class TreasureSpawner : MonoBehaviour
{
    public List<GameObject> TreasureChestLocations;
    int activeIndex;
    public TreasureChest activeChest;

    void Start()
    {
        GenerateChestLocation();
    }

    private void Update()
    {
        if (activeChest.surfaced)
        {
            GenerateChestLocation();
        }
    }

    public void GenerateChestLocation()
    {
        if (TreasureChestLocations.Count < 1) return;
        while (true)
        {
            int index = Random.Range(0, TreasureChestLocations.Count - 1);
            if (activeIndex != index || TreasureChestLocations.Count == 1)
            {
                activeIndex = index;
                break;
            }
        }

        for (int i = 0; i < TreasureChestLocations.Count; i++)
        {
            TreasureChestLocations[i].SetActive(i == activeIndex);
        }
        activeChest = TreasureChestLocations[activeIndex].GetComponent<TreasureChest>();
        Debug.Log(activeChest.coordinate);
    }

    public void SetChestIcons(bool isActive)
    {
        for (int i = 0; i < TreasureChestLocations.Count; i++)
        {
            TreasureChest chest = TreasureChestLocations[i].GetComponent<TreasureChest>();
            chest.Icon.SetActive(isActive);
        }
    }
}
