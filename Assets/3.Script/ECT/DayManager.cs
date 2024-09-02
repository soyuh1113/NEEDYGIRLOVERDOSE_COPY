using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum DayType
{
    Afternoon,
    Dinner,
    Night
}

public class DayManager : MonoBehaviour
{
    public DayType daytype;

    [SerializeField] private TextMeshProUGUI today;
    [SerializeField] private TextMeshProUGUI nextday;


}
