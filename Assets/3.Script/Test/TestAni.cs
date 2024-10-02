using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAni : MonoBehaviour
{
    private Animator ani;

    private void Awake()
    {
        ani = GetComponent<Animator>();
    }

    public void Test(string aniName)
    {
        ani.Play(aniName);
    }
}
