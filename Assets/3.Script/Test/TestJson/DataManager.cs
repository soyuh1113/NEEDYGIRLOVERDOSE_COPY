using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;    //어딘가로 데이터를 넣거나 가져올 때 쓴다

/* 저장하는 방법
1. 저장할 데이터가 존재
2. 데이터를 제이슨으로 변환
3. 제이슨을 외부에 저장

   불러오는 방법
1. 외부에 저장된 제이슨을 가져옴
2. 제이슨을 데이터 형태로 변환
3. 불러온 데이터를 사용
*/

public class PlayerData //저장할 데이터
{
    //이름, 레벨, 코인, 착용중인 무기
    public string name;
    public int level;
    public int coin;
    public int item;
}

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    PlayerData nowPlayer = new PlayerData();

    string path;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        path = Application.persistentDataPath;
    }

    private void Start()
    {
        string data = JsonUtility.ToJson(nowPlayer);

        //print

        //File.WriteAllText(data);
    }


}
