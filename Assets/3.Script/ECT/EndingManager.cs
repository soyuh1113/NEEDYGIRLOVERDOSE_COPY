using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : MonoBehaviour
{
    /*
     1. 커먼 엔딩(10일째 밤에 팔로워 1만 명 미만)
     2. JINE 엔딩(JINE 6회 무시)
     3. 배드엔딩(호감도 0) or 건전 엔딩(멘탈 0)
     4. 일하는 엔딩(호감도만 60 이상)
     5. 창작 엔딩(1 ~ 4 조건 불충족)
     6. 모작 엔딩(모든 엔딩 감상)
     */

    [SerializeField] private int disregardCount;    //JINE 무시 횟수

    public void Ending()
    {
        //if ()
        //{
        //    Normal_End();
        //}
    }

    private void Normal_End()
    {

    }

    private void JINE_End()
    {

    }

    private void Bad_End()
    {

    }

    private void Work_End()
    {

    }

    private void New_End()
    {

    }

    private void All_End()
    {

    }
}
