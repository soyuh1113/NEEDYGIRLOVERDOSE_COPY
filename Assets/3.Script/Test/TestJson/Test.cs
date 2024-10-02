using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
관련 영상 링크 : https://www.youtube.com/watch?v=-Myy_fRljo0&t=1s
1. 데이터(코드 = 클래스)를 만들어야함. => 저장할 데이터 생성
2. 그 데이터를 Json으로 변환(택배상자로 포장)
========================================================================
1. Json(택배)를 다시 원래의 코드로 바꾸는 방법
   Json(택배) -> 조립도 -> 클래스(코드)
 */

//데이터(코드 = 클래스) 제작
class Data  //저장하고 싶은 모든 걸 넣기
{
    public string nickname;
    public int level;
    public int coin;
    public bool skill;
    //기타 등등
}

public class Test : MonoBehaviour
{
    Data player = new Data() { nickname = "Json", level = 50, coin = 200, skill = false };   //Data 정보를 갖고 있는 player라는 객체 생성

    //Json으로 변환
    private void Start()
    {
        //Json은 항상 string
        string jsonData = JsonUtility.ToJson(player);

        Data player2 = JsonUtility.FromJson<Data>(jsonData);
        print(player2.nickname);
        print(player2.level);
        print(player2.coin);
        print(player2.skill);
    }
}
