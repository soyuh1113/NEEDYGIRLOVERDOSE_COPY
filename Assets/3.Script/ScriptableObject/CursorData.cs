using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cursor Data", menuName = "ScriptableObject/Cursor Data", order = 1)]
public class CursorData : ScriptableObject
{
    [SerializeField]
    private Texture2D cursor;
    public Texture2D Cursor { get { return cursor; } }

    [SerializeField]
    private Texture2D diagonal1;
    public Texture2D Diagonal1 { get { return diagonal1; } }

    [SerializeField]
    private Texture2D diagonal2;
    public Texture2D Diagonal2 { get { return diagonal2; } }

    [SerializeField]
    private Texture2D hand;
    public Texture2D Hand { get { return hand; } }

    [SerializeField]
    private Texture2D horizontal;
    public Texture2D Horizontal { get { return horizontal; } }

    [SerializeField]
    private Texture2D hourglass;
    public Texture2D Hourglass { get { return hourglass; } }

    [SerializeField]
    private Texture2D prohibition;
    public Texture2D Prohibition { get { return prohibition; } }

    [SerializeField]
    private Texture2D vertical;
    public Texture2D Vertical { get { return vertical; } }
}
