using DG.Tweening;
using TMPro;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    public Vector2 coordinate;
    public bool AddedCoin;
    public float treasureValue;
    public AudioSource coinSound;
    public GameObject Icon;
    public GameObject ChestPrefab;
    public GameObject currentChestPrefab;
    public Vector3 buryOffset;
    public bool surfaced;
    public Material dissoveMat;
    public float dissoveDuration;

    private PlayerState playerState;

    // Coin pickup UI
    public TextMeshProUGUI coinAmountText;
    public GameObject coinPickupUI;

    private void Awake()
    {
        playerState = FindObjectOfType<PlayerState>();
    }

    public void surfaceChest(Vector3 location)
    {
        currentChestPrefab = Instantiate(ChestPrefab, location + buryOffset, transform.rotation);
        dissoveMat.DOFloat(-1f, "_DissovePercent", 0.01f);
        currentChestPrefab.transform.DOMove(location, 1f);
        if (!AddedCoin)
        {
            AddedCoin = true;
            if (!coinSound.isPlaying)
                coinSound.Play();
            playerState.goldAmount += treasureValue;
            ShowCoinPickupUI(treasureValue);
        }
        Invoke(nameof(HideChest), 4f);
    }

    private void ShowCoinPickupUI(float treasureValue)
    {
        coinAmountText.text = " + " + treasureValue.ToString();
        coinPickupUI.SetActive(true);
        Invoke(nameof(HideCoinPickupUI), 2f);
    }

    private void HideCoinPickupUI()
    {
        coinPickupUI.SetActive(false);
    }

    public void HideChest()
    {
        surfaced = true;
        dissoveMat.DOFloat(1f, "_DissovePercent", dissoveDuration);
        Destroy(currentChestPrefab, 4f);
        Invoke(nameof(setSurfaceToFalse), 4f);
        AddedCoin = false;
    }
    private void setSurfaceToFalse()
    {
        surfaced = false;
    }
}
