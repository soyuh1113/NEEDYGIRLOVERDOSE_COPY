using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum TimeType
{
    Afternoon,
    Evening,
    Night
}

public class TestDay2 : MonoBehaviour
{
    public TestEnd testend;

    public TimeType timetype = TimeType.Night;

    private Dictionary<TimeType, string> timeType = new Dictionary<TimeType, string>
    {
        { TimeType.Afternoon, "��"},
        { TimeType.Evening, "����"},
        { TimeType.Night, "��"}
    };

    private int totalDay = 10;
    private int currentDay = 1;

    [SerializeField] private Sprite[] day_Img;
    [SerializeField] private TextMeshProUGUI today_txt;
    [SerializeField] private TextMeshProUGUI nexttime_txt;

    [SerializeField] private GameObject Background1;
    [SerializeField] private GameObject Background2;
    [SerializeField] private Sprite[] Background;

    public void UpdateTime()
    {
        if(timeType.TryGetValue(timetype, out string timeTypes))
        {
            today_txt.text = "Day" + currentDay + timeTypes;
            nexttime_txt.text = timeTypes + "����";
        }
    }

    public void UpdateBg()
    {
        Sprite bg1 = Background1.GetComponent<Sprite>();
        Sprite bg2 = Background2.GetComponent<Sprite>();

        switch (timetype)
        {
            case TimeType.Afternoon:
                //bg1.sprite = Background[0];
                break;
            case TimeType.Evening:
                break;
            case TimeType.Night:
                break;

        }
    }

    public void OnActionBtn()
   {
        timetype = (TimeType)(((int)timetype + 1) % 3);
        UpdateTime();
   }
   
   public void SkipTime()
   {
        if (timetype == TimeType.Afternoon)
        {
            timetype = (TimeType)(((int)timetype + 2) % 3);
            UpdateTime();
        }
        else if(timetype == TimeType.Evening)
        {
            OnNextBtn();
        }
    }

    public void OnNextBtn()
    {
        if (currentDay == totalDay && timetype == TimeType.Night)
        {
            Debug.Log("���� ��~ ����!");
            testend.End();
            return;
        }

        currentDay++;
        timetype = TimeType.Afternoon;
        UpdateTime();
        Debug.Log(currentDay);
    }
}