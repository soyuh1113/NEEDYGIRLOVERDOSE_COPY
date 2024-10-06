using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmeAction : MonoBehaviour
{
    private StatData statData;

    private Animator ani;

    private void Start()
    {
        ani = GetComponent<Animator>();
        statData = gameObject.GetComponent<StatData>();
    }

    //애니메이션 이름과 a_action 이름 통일하기
    public void A_Action(string a_action)
    {
        switch (a_action)
        {
            case "Live":
                break;
            case "Game":
                ani.Play(a_action);
                break;
            case "Communication":
                break;
            case "adult_Play":
                break;
            case "R_Evening":
                break;
            case "R_Night":
                break;
            case "R_NextDay":
                break;
            case "TM_DepasTab":
                break;
            case "TM_PronTab":
                break;
            case "SNS":
                break;
            case "Serch":
                break;
            case "Movie":
                break;
            case "Boarder":
                break;
            case "Tinder":
                break;
            case "Out":
                break;
        }
    }



}
