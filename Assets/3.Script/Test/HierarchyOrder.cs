using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HierarchyOrder : MonoBehaviour
{
    public GameObject parentObject; 
    public Sprite imageA;  
    public Sprite imageB;  

    public void UpdateChildImages()
    {
        if (parentObject.transform.childCount > 0)
        {
            Transform firstChild = parentObject.transform.GetChild(0);

            for (int i = 0; i < parentObject.transform.childCount; i++)
            {
                Transform child = parentObject.transform.GetChild(i);
                Image childImage = child.GetComponent<Image>();

                if (child == firstChild)
                {
                    childImage.sprite = imageA;
                }
                else
                {
                    childImage.sprite = imageB;
                }
            }
        }
    }

    public void MoveToLastSibling(GameObject obj)
    {
        obj.transform.SetAsLastSibling();
        UpdateChildImages();
    }
}
