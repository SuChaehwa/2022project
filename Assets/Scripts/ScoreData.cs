using System.Collections;
using System.Collections.Generic;
using System.IO;
//using System.IO;
//using System.Text;
using UnityEngine;
//using Newtonsoft.Json;
using UnityEngine.UI;
class Data
{
    public List<string> name = new List<string>();
    public List<int> score = new List<int>();
}
public class ScoreData : MonoBehaviour
{
    Data player = new Data();

    public InputField inputName;

    // Start is called before the first frame update
    void Start()
    {
        LoadPlayerNicknameDataToJson();
        player.score.Add(GameManager.instance.lastScore);
    }

    public void InName()
    {
        string playerNickname = inputName.text;
        player.name.Add(playerNickname);
        SavePlayerNicknameDataToJson();
    }

    public void SavePlayerNicknameDataToJson()
    {
        string jsonData = JsonUtility.ToJson(player, true);
        string path = Path.Combine(Application.dataPath, "Resources/playerNicknameData.json");
        File.WriteAllText(path, jsonData);
    }

    public void LoadPlayerNicknameDataToJson()
    {
        string path = Path.Combine(Application.dataPath, "Resources/playerNicknameData.json");
        string jsonData = File.ReadAllText(path);
        player = JsonUtility.FromJson<Data>(jsonData);
    }
}