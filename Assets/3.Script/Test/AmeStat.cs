using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmeStat : MonoBehaviour
{
    private StatData statData;

    private void Start()
    {
        statData = gameObject.GetComponent<StatData>();
    }

    public void UpdateStat()
    {
        statData.Follow += 1;
        Debug.Log(statData.Follow);
    }
}
