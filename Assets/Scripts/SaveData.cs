using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class SaveData : MonoBehaviour
{
    public static SaveData instance;
    
    public string nickName;
    public string bestNickName;

    public int score;
    public int bestScore;

    [Serializable]
    public class DataSave
    {
        public string bestNickName;
        public int bestScore;
    }
    
    private void Awake()
    {
        Load();
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Save()
    {
        DataSave data = new DataSave();
        data.bestNickName = bestNickName;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);
  
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            DataSave data = JsonUtility.FromJson<DataSave>(json);

            bestScore = data.bestScore;
            bestNickName = data.bestNickName;
        }
    }
}
