using UnityEngine;

public class DifficultyLoader : MonoBehaviour
{
    public GameObject PlayerIcon;
    public TreasureSpawner treasureSpawner;

    private void Awake()
    {
        treasureSpawner = FindObjectOfType<TreasureSpawner>();
    }

    public void LoadEasy()
    {
        PlayerIcon.SetActive(true);
        treasureSpawner.SetChestIcons(true);
    }
    public void LoadNormal()
    {
        PlayerIcon.SetActive(true);
        treasureSpawner.SetChestIcons(false);
    }
    public void LoadHard()
    {
        PlayerIcon.SetActive(false);
        treasureSpawner.SetChestIcons(false);
    }
}
