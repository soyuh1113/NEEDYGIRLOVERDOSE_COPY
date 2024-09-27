using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;    //��򰡷� �����͸� �ְų� ������ �� ����

/* �����ϴ� ���
1. ������ �����Ͱ� ����
2. �����͸� ���̽����� ��ȯ
3. ���̽��� �ܺο� ����

   �ҷ����� ���
1. �ܺο� ����� ���̽��� ������
2. ���̽��� ������ ���·� ��ȯ
3. �ҷ��� �����͸� ���
*/

public class PlayerData //������ ������
{
    //�̸�, ����, ����, �������� ����
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
