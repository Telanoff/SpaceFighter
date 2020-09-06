using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class DataUtil
{
    public static void Serialize(object o, string filename)
    {
        BinaryFormatter fmt = new BinaryFormatter();
        string path = Application.dataPath + $"/{filename}";

        FileStream fs = new FileStream(path, FileMode.Create);

        fmt.Serialize(fs, o);
        fs.Close();
    }

    public static bool LoadSerialized<T>(string filename, out T o)
    {
        string path = Application.dataPath + $"/{filename}";

        if (!File.Exists(path))
        {
            Debug.LogError($"Path: '{filename}' does not exist! Ignoring.");
            o = default(T);
            return false;
        }

        BinaryFormatter fmt = new BinaryFormatter();
        FileStream fs = new FileStream(path, FileMode.Open);

        o = (T) fmt.Deserialize(fs);

        fs.Close();

        return true;
    }

    public static bool Exists(string filename)
    {
        return File.Exists(Application.dataPath + $"/{filename}");
    }
}