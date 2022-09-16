using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float Interval;
    [SerializeField] private float countDown;

    public void setInterval(float IntervalParameter)
    {
        Interval = IntervalParameter;
    }
    // Start is called before the first frame update
    void Start()
    {
        countDown = Interval;
    }

    // Update is called once per frame
    void Update()
    {
        countDown -= Time.deltaTime;
        countDown = Mathf.Max(countDown, 0);
    }

    public float getRemainingTime()
    {
        return countDown;
    }
    public float getPercentageDone()
    {
        return 1 - (countDown / Interval);
    }

    public bool isTimeUp()
    {
        return countDown <= 0;
    }

    public void ResetTimer()
    {
        countDown = Interval;
    }
}
