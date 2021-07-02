using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveSystem
{
    public static GameData LoadSettings(){
        string path = Application.persistentDataPath + "/simulation.death";
        if (File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();
            return data;
        }

        else{ 
            Debug.LogError("Save file not found in " + path);
            return null;
        }

    }

    public static void SaveGame(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/simulation.death";
        FileStream stream = new FileStream(path, FileMode.Create);
        GameData data = new GameData(player);
        formatter.Serialize(stream, data);
        stream.Close();
    }
}
