using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HierarchyOrder : MonoBehaviour
{
    public void testbtn()
    {
        GameObject goRed = GameObject.Find("Canvas/TestUI");
        GameObject goBlue = GameObject.Find("Canvas/TestUI (1)");

        Debug.Log("before goRed : " + goRed.transform.GetSiblingIndex());
        Debug.Log("before goBlue : " + goBlue.transform.GetSiblingIndex());

        goRed.transform.SetSiblingIndex(0);
        Debug.Log("after goRed : " + goRed.transform.GetSiblingIndex());
        Debug.Log("after goBlue : " + goBlue.transform.GetSiblingIndex());
    }
}
