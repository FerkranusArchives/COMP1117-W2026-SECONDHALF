using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private string savePath;    // Store the path where my game will be saved

    private void Awake()
    {
        savePath = Application.persistentDataPath + "/player_save.json"; // unity given save
    }

    // Save Game
    public void SaveGame(Vector3 playerPos)
    {
        // Format our player position data to save to file.
        PlayerSaveData data = new PlayerSaveData();
        data.position[0] = playerPos.x;
        data.position[1] = playerPos.y;
        data.position[2] = playerPos.z;

        // 1. Save our data in a JSON format, value saves to string variable
        string json = JsonUtility.ToJson(data, true); // Optional 2nd argument for pretty print. True makes the file readable to humans
        // 2. Write to a JSON file
        File.WriteAllText(savePath, json);
        Debug.Log("Game Saved to: " + savePath);
    }

    // Load Game
    public Vector3 LoadGame()
    {
        if(File.Exists(savePath))
        {
            // File exists! (gotta exist to do anything. duh)
            string json = File.ReadAllText(savePath);   // Load the JSON string from savePath

            PlayerSaveData data = JsonUtility.FromJson<PlayerSaveData>(json); // Convert the JSON string into a PlayerSaveData variable
            Vector3 playerData = new Vector3(data.position[0], data.position[1], data.position[2]); // getting data of xyz saved previously into list
            return playerData; // give that back
        }

        Debug.LogWarning("No save file found at " + savePath); // specifies where the save file wasn't found
        return Vector3.zero; // all paths must return a value, if no file then no position
    }
}
