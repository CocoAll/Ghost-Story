using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SavingManager: MonoBehaviour
{
    [SerializeField]
    private List<SaveData> saveDatas = new List<SaveData>();

    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        StreamWriter file = new StreamWriter(Application.persistentDataPath + "/data.sav");
        MemoryStream ms = new MemoryStream();
        saveDatas = new List<SaveData>();
        RoomDoorController[] rdc = FindObjectsOfType<RoomDoorController>();

        foreach (RoomDoorController obj in rdc)
        {
            saveDatas.Add(new SaveData(obj.GetName(), obj.GetOrderRespected()));
        }

        bf.Serialize(ms, saveDatas);
        string a = Convert.ToBase64String(ms.ToArray());
        file.WriteLine(a);
        file.Close();
        Debug.Log("Game data saved!");
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/data.sav"))
        {

            BinaryFormatter bf = new BinaryFormatter();
            StreamReader file = new StreamReader(Application.persistentDataPath + "/data.sav");
            string a = file.ReadToEnd();
            MemoryStream ms = new MemoryStream(Convert.FromBase64String(a));
            saveDatas = bf.Deserialize(ms) as List<SaveData>;

            RoomDoorController[] rdc = FindObjectsOfType<RoomDoorController>();
            foreach (RoomDoorController obj in rdc)
            {
                SaveData sd = saveDatas.Find(sdObj => { return sdObj.doorName.Equals(obj.GetName()); });
                obj.SetOrderRespected(sd.doorValue);
            }
            Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("There is no save data!");
    }

    public void ResetGame()
    {
        if (File.Exists(Application.persistentDataPath + "/data.sav"))
        {
            File.Delete(Application.persistentDataPath + "/data.sav");
            RoomDoorController[] rdc = FindObjectsOfType<RoomDoorController>();
            saveDatas = new List<SaveData>();
            foreach (RoomDoorController obj in rdc)
            {
                obj.SetOrderRespected(false);
                saveDatas.Add(new SaveData(obj.GetName(), obj.GetOrderRespected()));
            }
            Debug.Log("Data reset complete!");
        }
        else
            Debug.LogError("No save data to delete.");
    }

}
    [Serializable]
    class SaveData
    {
        public string doorName;
        public bool doorValue;

        public SaveData(string doorName, bool doorValue)
        {
            this.doorName = doorName;
            this.doorValue = doorValue;
        }
    }

