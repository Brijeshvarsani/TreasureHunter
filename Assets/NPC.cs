using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Interact()
    {
        if (menu != null)
            menu.SetActive(true);
    }
}
