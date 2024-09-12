using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum DayType
{
    Afternoon,
    Evening,
    Night
}

public class TestDay : MonoBehaviour
{
    public DayType daytype;

    private int totalDay = 30;
    private int currentDay = 1;

    [SerializeField] private TextMeshProUGUI today;
    [SerializeField] private TextMeshProUGUI nextday;

    private bool isActionComplete = false;

    public Button[] actionButtons;
    private int[] skipButtons = { 2, 5, 8 };

    void Start()
    {
        daytype = DayType.Afternoon;
        UpdateUI();
    }

    public void OnActionButtonClick(int actionIndex)
    {
        if (!isActionComplete)
        {
            PerformAction(actionIndex);
        }
        else
        {
            MoveToNextPeriod();
        }
    }

    void PerformAction(int actionIndex)
    {
        Debug.Log("Performing action: " + actionIndex + " during " + daytype);

        isActionComplete = true;

        if (IsSkipButton(actionIndex))
        {
            SkipPeriod();
        }
        else
        {
            today.text = "Action completed for " + daytype + ". Press any button to continue.";
        }
    }

    void SkipPeriod()
    {
        if (daytype == DayType.Afternoon)
        {
            daytype = DayType.Night;
            Debug.Log("Skipping to Night.");
        }
        else if (daytype == DayType.Evening)
        {
            currentDay++;
            daytype = DayType.Afternoon;
            Debug.Log("Skipping to next Day.");
        }

        today.text = "Action skipped to " + daytype + ". Press any button to continue.";
    }

    void MoveToNextPeriod()
    {
        if (daytype == DayType.Afternoon)
        {
            daytype = DayType.Evening;
        }
        else if (daytype == DayType.Evening)
        {
            daytype = DayType.Night;
        }
        else if (daytype == DayType.Night)
        {
            currentDay++;
            if (currentDay <= totalDay)
            {
                daytype = DayType.Afternoon;
                Debug.Log("Day " + currentDay + " starts.");
            }
            else
            {
                Debug.Log("All days completed.");
                today.text = "Game Over!";
                return;
            }
        }

        isActionComplete = false;
        UpdateUI();
    }

    void UpdateUI()
    {
        today.text = "Day " + currentDay + ": " + daytype + ". Choose an action.";
    }

    bool IsSkipButton(int actionIndex)
    {
        foreach (int skipIndex in skipButtons)
        {
            if (actionIndex == skipIndex)
            {
                return true;
            }
        }
        return false;
    }
}
