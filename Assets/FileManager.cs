using System;
using System.IO;
using UnityEngine;

public class FileManager {
    public static string GetPath (string name) {
        return Path.Combine(Application.persistentDataPath, name);
    }

    public static void SaveJson (string name, object value) {
        var json = JsonUtility.ToJson(value);
        File.WriteAllText(GetPath(name), json);
    }

    public static T LoadJson<T> (string name) {
        try {
            var json = File.ReadAllText(GetPath(name));
            return JsonUtility.FromJson<T>(json);
        } catch (FileNotFoundException) {
            return Activator.CreateInstance<T>();
        }
    }
}
