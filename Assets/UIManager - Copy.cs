using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI locationText;
    public TextMeshProUGUI goldText;
    public GameObject map;

    GameState gameState;
    private TreasureSpawner treasureSpawner;
    private PlayerState playerState;
    private PlayerInteract playerInteract;
    private StarterAssetsInputs _input;
    public TextMeshProUGUI timerText;
    public bool StartLockCursor;
    public Button selectButton;
    public Material material1;
    public Material material2;
    public Material material3;
    public MeshRenderer shovel;

    public GameObject interactButton;
    public GameObject shopUI;
    public GameObject mainMenu;




    private void Awake()
    {
        treasureSpawner = FindObjectOfType<TreasureSpawner>();
        playerState = FindObjectOfType<PlayerState>();
        playerInteract = FindObjectOfType<PlayerInteract>();
        _input = FindObjectOfType<StarterAssetsInputs>();
        gameState = FindObjectOfType<GameState>();
        SetCursorLocked(StartLockCursor);
        selectButton.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isUIActive())
        {
            SetCursorLocked(false);
        }
        else
        {
            SetCursorLocked(true);
        }


        locationText.text = "treasure is at (" + treasureSpawner.activeChest.coordinate.x + "," + treasureSpawner.activeChest.coordinate.y + ")";
        goldText.text = playerState.goldAmount.ToString();

        interactButton.SetActive(playerInteract.canInteract);

        if (_input.map)
        {
            toggleMap();
            _input.map = false;
        }

        timerText.text = m_Util.secondsToMinSec(Mathf.RoundToInt(gameState.timer.getRemainingTime()));
    }

    private bool isUIActive()
    {
        return shopUI.activeInHierarchy || mainMenu.activeInHierarchy;
    }

    public void toggleMap()
    {
        map.SetActive(!map.activeInHierarchy);
    }

    public void SetCursorLocked(bool state)
    {
        _input.cursorLocked = state;
        _input.cursorInputForLook = state;
        _input.SetCursorState(state);
    }

    public void Quit()
    {
        Application.Quit();
    }


    public void BuyShovel1()
    {
        if (playerState.goldAmount > 50)
        {
            playerState.goldAmount = playerState.goldAmount - 50;
            selectButton.interactable = true;
            shovel.material = material1;

        }
    }

    public void BuyShovel2()
    {
        if (playerState.goldAmount > 200)
        {
            playerState.goldAmount = playerState.goldAmount - 200;
            selectButton.interactable = true;
            shovel.material = material2;
        }
    }

    public void BuyShovel3()
    {
        if (playerState.goldAmount > 500)
        {
            playerState.goldAmount = playerState.goldAmount - 500;
            selectButton.interactable = true;
            shovel.material = material3;
        }
    }
}



