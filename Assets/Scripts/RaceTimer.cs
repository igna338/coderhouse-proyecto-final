using UnityEngine;
using UnityEngine.UI;

public class RaceTimer : MonoBehaviour
{
    public GameEvents gameEvents;
    public int minutes, seconds;
    public Text timeRemainingText;
    private string stringMinutes, stringSeconds;

    public void ResumeTime()
    {
        InvokeRepeating("TimeDeduction", 0, 1);//0s delay, 1s repeat
    }

    public void StopTime()
    {
        CancelInvoke("TimeDeduction");
    }

    private void TimeDeduction()
    {
        if (seconds == 0)
        {
            if (minutes > 0)
            {
                minutes--;
                seconds = 59;
            }
            else
                FinishMatch();
        }
        else
        {
            seconds--;
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        stringMinutes = minutes.ToString();
        if (stringMinutes.Length == 1)
            stringMinutes = "0" + stringMinutes;

        stringSeconds = seconds.ToString();
        if (stringSeconds.Length == 1)
            stringSeconds = "0" + stringSeconds;

        timeRemainingText.text = stringMinutes + ":" + stringSeconds;
    }

    private void FinishMatch()
    {
        gameEvents.RaceTimerEvent.Invoke();
    }
}
