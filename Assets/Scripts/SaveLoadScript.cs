using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
public class SaveLoadScript : MonoBehaviour
{
    string saveFileName = "saveFile.json";

    [Serializable]
    public class GameData
    {
        public int characterIndex;
        public string playerName;
        //And other stats... position, time, etc.
    }

    private GameData gameData = new GameData();

    public void SaveGame(int character, string name)
    {
        gameData.characterIndex = character;
        gameData.playerName = name;

        string json = JsonUtility.ToJson(gameData);
        File.WriteAllText(Application.persistentDataPath + "/" + saveFileName, json);

        Debug.Log("Game Saved to:"+
        Application.persistentDataPath + "/" + saveFileName);
    }
    public void LoadGame()
    {
        string filePath = Application.persistentDataPath + "/" + saveFileName;

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            gameData = JsonUtility.FromJson<GameData>(json);

            Debug.Log("Game Loaded from: " + filePath +
            "\nCharacter Index: " + gameData.characterIndex +
            "\nPlayer Name: " + gameData.playerName);
        }
        else
        {
            Debug.LogError("Save file not found in: " + filePath);
        }
    }
}
