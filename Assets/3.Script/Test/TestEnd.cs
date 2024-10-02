using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnd : MonoBehaviour
{
    public bool end1 = false;
    public bool end2 = false;

    public void End()
    {
        if (end1)
        {
            End1();
        }
        else if (end2)
        {
            End2();
        }
        else
        {
            End3();
        }
    }

    private void End1()
    {
        Debug.Log("엔딩1");
    }

    private void End2()
    {
        Debug.Log("엔딩2");
    }

    private void End3()
    {
        Debug.Log("엔딩3");
    }

    private void End4()
    {
        Debug.Log("엔딩4");
    }

    private void End5()
    {
        Debug.Log("엔딩5");
    }
}
