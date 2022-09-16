using UnityEngine;

public class GameState : MonoBehaviour
{
    public Timer timer;
    public float timeLeft;

    private void Awake()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.setInterval(timeLeft);
    }
}
