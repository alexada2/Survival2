using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class SaveSystem : MonoBehaviour
{
    public int password;
    public string login;
    private string path;
    private PlayerData playerData;
    public Text text;

    private void Start()
    {
        playerData = new PlayerData();
        path = Path.Combine(Application.dataPath, "Resources/Data/save.json");
    }
    [ContextMenu("save")]
    public void Save()
    {
        playerData.login = login;
        playerData.password = password;
        File.WriteAllText(path, JsonUtility.ToJson(playerData));
    }
    [ContextMenu("load")]
    public void Load()
    {
        playerData = JsonUtility.FromJson<PlayerData>(File.ReadAllText(path));
        login = playerData.login;
        password = playerData.password;
    }
}
