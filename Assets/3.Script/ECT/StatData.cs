using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatData : MonoBehaviour
{
    [Header("Stat")]
    [SerializeField] private int follow;        //팔로워
    [SerializeField] private int stress;        //스트레스
    [SerializeField] private int likeability;   //호감도
    [SerializeField] private int mental;        //멘탈

    [Header("Live Bonus")]
    [SerializeField] private int prior_notice;  //사전 공지
    [SerializeField] private int movie;         //영화 지식
    [SerializeField] private int experience;    //경험
    [SerializeField] private int talk;          //대화 능력
    [SerializeField] private int game;          //게임
    [SerializeField] private int madness;       //광기

    public int Follow { get { return follow; } set { follow = value; } }
    public int Stress { get { return stress; } set { stress = value; } }
    public int Likeability { get { return likeability; } set { likeability = value; } }
    public int Mental { get { return mental; } set { mental = value; } }
    public int Prior_Notice { get { return prior_notice; } set { prior_notice = value; } }
    public int Movie { get { return movie; } set { movie = value; } }
    public int Experience { get { return experience; } set { experience = value; } }
    public int Talk { get { return talk; } set { talk = value; } }
    public int Game { get { return game; } set { game = value; } }
    public int Madness { get { return madness; } set { madness = value; } }

    private void Start()
    {
        follow = 1;
        stress = 0;
        likeability = 1;
        mental = 0;

        prior_notice = 1;
        movie = 1;
        experience = 1;
        talk = 1;
        game = 1;
        madness = 1;
    }
}
