using UnityEngine;
using UnityEngine.UI;

public class RaceTimer : MonoBehaviour
{
    public GameEvents gameEvents;
    public PlayerCar playerCar;
    public int minutes, seconds;
    public Text timeText;
    public Image timePanel;
    public Text countdownText;
    public Image countdownPanel;
    private int countdownSeconds = 4;
    private string stringMinutes, stringSeconds;

    public void StartRaceCountdown()
    {
        InvokeRepeating("RaceCountdown", 0, 1);//0s delay, 1s repeat
    }

    private void RaceCountdown()
    {
        countdownSeconds--;
        //race start:
        if (countdownSeconds == 0)
        {
            StartTimer();
            CancelInvoke("RaceCountdown");
            playerCar.enabled = true;
            countdownText.enabled = false;
            countdownPanel.enabled = false;
            timeText.enabled = true;
            timePanel.enabled = true;
        }

        UpdateCountdownUI();
    }

    private void UpdateCountdownUI()
    {
        countdownText.text = countdownSeconds.ToString();
    }

    private void StartTimer()
    {
        InvokeRepeating("TimeDeduction", 0, 1);//0s delay, 1s repeat
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
                FinishRace();
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

        timeText.text = stringMinutes + ":" + stringSeconds;
    }

    private void FinishRace()
    {
        gameEvents.RaceTimerEvent.Invoke();
    }
}
