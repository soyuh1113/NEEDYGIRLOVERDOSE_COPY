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

    private Dictionary<DayType, string> daytypes = new Dictionary<DayType, string>
    {
        { DayType.Afternoon, "³·" },
        { DayType.Evening, "Àú³á" },
        { DayType.Night, "¹ã" },
    };

    private int totalDay = 10;
    private int currentDay = 1;

    [SerializeField] private TextMeshProUGUI today;
    [SerializeField] private TextMeshProUGUI nextday;

    private bool isActionComplete = false;

    public Button[] actionButtons;
    private int[] skipButtons = { 2, 5, 8 };

    private void Start()
    {
        daytype = DayType.Afternoon;
        UpdateTxt();
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

    public void PerformAction(int actionIndex)
    {
        Debug.Log("Performing action: " + actionIndex + " during " + daytype);

        isActionComplete = true;

        if (IsSkipButton(actionIndex))
        {
            SkipPeriod();
        }
        else
        {
            today.text = "Action completed for " + daytype;
        }
    }

    public void SkipPeriod()
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

        today.text = "Action skipped to " + daytype;
    }

    public void MoveToNextPeriod()
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
                Debug.Log("Day " + currentDay);
            }
            else
            {
                Debug.Log("All days completed.");
                today.text = "°ÔÀÓ ³¡";
                return;
            }
        }

        isActionComplete = false;
        UpdateTxt();
    }

    public void UpdateTxt()
    {
        if(daytypes.TryGetValue(daytype,out string dayType))
        {
            today.text = "Day " + currentDay + ": " + dayType;
        }
    }

    public bool IsSkipButton(int actionIndex)
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
