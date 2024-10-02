using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
���� ���� ��ũ : https://www.youtube.com/watch?v=-Myy_fRljo0&t=1s
1. ������(�ڵ� = Ŭ����)�� ��������. => ������ ������ ����
2. �� �����͸� Json���� ��ȯ(�ù���ڷ� ����)
========================================================================
1. Json(�ù�)�� �ٽ� ������ �ڵ�� �ٲٴ� ���
   Json(�ù�) -> ������ -> Ŭ����(�ڵ�)
 */

//������(�ڵ� = Ŭ����) ����
class Data  //�����ϰ� ���� ��� �� �ֱ�
{
    public string nickname;
    public int level;
    public int coin;
    public bool skill;
    //��Ÿ ���
}

public class Test : MonoBehaviour
{
    Data player = new Data() { nickname = "Json", level = 50, coin = 200, skill = false };   //Data ������ ���� �ִ� player��� ��ü ����

    //Json���� ��ȯ
    private void Start()
    {
        //Json�� �׻� string
        string jsonData = JsonUtility.ToJson(player);

        Data player2 = JsonUtility.FromJson<Data>(jsonData);
        print(player2.nickname);
        print(player2.level);
        print(player2.coin);
        print(player2.skill);
    }
}
