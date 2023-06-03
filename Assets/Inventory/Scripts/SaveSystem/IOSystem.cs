using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public static class IOSystem
{

    private static string _path = Application.dataPath + Path.AltDirectorySeparatorChar + "Data.json";
    public static void SaveData<T>(T data) where T : new()
    {
        string json = JsonUtility.ToJson(data);
        WriteFile(json);
    }

    public static void SaveData<T>(List<T> data) where T : CellSaveData
    {
        string json = JsonHelper.ToJson<T>(data.ToArray());
        WriteFile(json);
    }

    private static void WriteFile(string content)
    {
        FileStream fileStream = new FileStream(_path,FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(content);
        }
    }

    public static List<T> LoadData<T>() where T: new()
    {
        string content = ReadFile();
        
        if(string.IsNullOrEmpty(content) || content == "{}" )
        {
            return new List<T>();
        }

        List<T> res = JsonHelper.FromJson<T>(content).ToList();
        return res;
    }

    private static string ReadFile()
    {
        if(File.Exists(_path))
        {
            using (StreamReader reader = new StreamReader(_path))
            {
                string content = reader.ReadToEnd();
                return content;
            }
        }

        return "";
    }

    public static bool IsCheckFile()
    {
        return File.Exists(_path);
    }


}




public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}