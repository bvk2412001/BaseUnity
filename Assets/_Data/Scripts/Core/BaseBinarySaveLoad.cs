using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class BaseBinarySaveLoad<T> where T : class
{
    protected string filePath;

    public BaseBinarySaveLoad(string fileName)
    {
        filePath = Application.persistentDataPath + "/" + fileName;
    }

    // 📌 Lưu dữ liệu với Generic
    public void SaveData(T data)
    {
        BinaryFormatter formatter = new();
        using (FileStream stream = new(filePath, FileMode.Create))
        {
            formatter.Serialize(stream, data);
        }
        Debug.Log($"Data saved at: {filePath}");
    }

    // 📌 Tải dữ liệu với Generic
    public T LoadData()
    {
        if (!File.Exists(filePath))
        {
            Debug.LogError($"Save file not found at: {filePath}");
            return null;
        }

        try
        {
            using FileStream stream = new(filePath, FileMode.Open);
            if (stream.Length == 0) // 📌 Kiểm tra file có rỗng không
            {
                Debug.LogError("Save file is empty!");
                return null;
            }

            BinaryFormatter formatter = new();
            return formatter.Deserialize(stream) as T;
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error loading save file: {ex.Message}");
            return null;
        }
    }
}

