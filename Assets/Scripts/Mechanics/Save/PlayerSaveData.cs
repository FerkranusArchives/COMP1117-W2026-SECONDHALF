using UnityEngine;

[System.Serializable] // any class that will store data
public class PlayerSaveData
{
    // When using JsonUtility, we must use SIMPLE data types (types in c# and not unity specific, so no vector3)
    // (float, float, float = x, y, z)
    public float[] position = new float[3];
}
