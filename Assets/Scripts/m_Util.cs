using UnityEngine;

public static class m_Util
{
    public static string secondsToMinSec(int timer)
    {
        float minutes = Mathf.Floor(timer / 60);
        float seconds = Mathf.RoundToInt(timer % 60);

        string secondsString;
        if (seconds < 10)
        {
            secondsString = "0" + Mathf.RoundToInt(seconds);
        }
        else
        {
            secondsString = Mathf.RoundToInt(seconds).ToString();
        }
        return minutes + ":" + secondsString;
    }
}
