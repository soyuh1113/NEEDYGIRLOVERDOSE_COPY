using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum DayType
{
    Afternoon,
    Evening,
    Night
}

public class DayManager : MonoBehaviour
{
    public DayType daytype;

    private int totalDay = 30;
    private int currentDay = 1;

    [SerializeField] private TextMeshProUGUI today;
    [SerializeField] private TextMeshProUGUI nextday;

    public void ClickBtn()
    {
        StartCoroutine(DayCycle());
    }

    IEnumerator DayCycle()
    {
        while (currentDay <= totalDay)
        {
            yield return StartCoroutine(StartNewDay());

            yield return StartCoroutine(AfternoonActivity());
            yield return StartCoroutine(EveningActivity());
            yield return StartCoroutine(NightActivity());

            currentDay++;
        }

        Debug.Log("All days completed.");
    }

    IEnumerator StartNewDay()
    {
        Debug.Log("Day " + currentDay + " starts.");

        daytype = DayType.Afternoon;
        Debug.Log("Current period: " + daytype);

        yield return null;
    }

    IEnumerator AfternoonActivity()
    {
        Debug.Log("Performing day activity...");

        yield return new WaitForSeconds(2);

        Debug.Log("Day activity completed.");

        daytype = DayType.Evening;
        Debug.Log("Current period: " + daytype);
    }

    IEnumerator EveningActivity()
    {
        Debug.Log("Performing evening activity...");

        yield return new WaitForSeconds(2);

        Debug.Log("Evening activity completed.");

        daytype = DayType.Night;
        Debug.Log("Current period: " + daytype);
    }

    IEnumerator NightActivity()
    {
        Debug.Log("Performing night activity...");

        yield return new WaitForSeconds(2);

        Debug.Log("Night activity completed.");
    }
}
