using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int BestScore;
    public string path;

    // Start is called before the first frame update
    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this);
        BestScore = 0;
        path = Application.persistentDataPath + "/savefile.json";
        LoadBestScore();
    }

    [System.Serializable]
    class SaveDate
    {
        public int BestScore;
    }

    public void SaveBestScore()
    {
        SaveDate saveDate = new SaveDate();
        saveDate.BestScore = BestScore;

        string json = JsonUtility.ToJson(saveDate);

        File.WriteAllText(path, json);
    }

    public void LoadBestScore()
    {
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveDate saveData = JsonUtility.FromJson<SaveDate>(json);
            BestScore = saveData.BestScore;

        }
    }
    
}
