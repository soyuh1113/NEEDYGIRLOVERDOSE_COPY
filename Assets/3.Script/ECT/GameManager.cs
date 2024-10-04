using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    private int totalDay = 10;

    [SerializeField] private bool normal_Ending;
    [SerializeField] private bool jine_Ending;
    [SerializeField] private bool bad_Ending;
    [SerializeField] private bool work_Ending;
    [SerializeField] private bool new_Ending;

    public Texture2D cursorTex;

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        Cursor.SetCursor(cursorTex, Vector2.zero, CursorMode.ForceSoftware);
    }
}
