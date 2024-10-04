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

    public void Action(string actname)
    {
        ani.Play(actname);  //애니메이션 출력
    }

    public void Live()
    {


    }

    public void Game()
    {

    }

    public void Communication()
    {

        
    }

    public void adult_Play()
    {

    }

    public void EveningSleep()
    {

    }

    public void NightSleep()
    {

    }

    public void NextDaySleep()
    {

    }

    public void TakeMedicine_DepasTab()
    {

    }

    public void TakeMedicine_PronTab()
    {

    }

    public void SNS()
    {

    }

    public void Search()
    {

    }

    public void Movie()
    {

    }

    public void Boarder()
    {

    }

    public void Tinder()
    {

    }

    public void Out()
    {

    }
}
