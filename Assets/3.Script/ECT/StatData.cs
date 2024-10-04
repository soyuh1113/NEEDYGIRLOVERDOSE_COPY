using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatData : MonoBehaviour
{
    [Header("Stat")]
    [SerializeField] private int follow;        //�ȷο�
    [SerializeField] private int stress;        //��Ʈ����
    [SerializeField] private int likeability;   //ȣ����
    [SerializeField] private int mental;        //��Ż

    [Header("Live Bonus")]
    [SerializeField] private int prior_notice;  //���� ����
    [SerializeField] private int movie;         //��ȭ ����
    [SerializeField] private int experience;    //����
    [SerializeField] private int talk;          //��ȭ �ɷ�
    [SerializeField] private int game;          //����
    [SerializeField] private int madness;       //����

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
