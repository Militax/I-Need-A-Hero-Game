using System;
using System.IO;
using System.Linq;
using UnityEngine;

using System.Collections.Generic;

namespace SaveSystem
{
	class SaveDictionary
	{
        static string saveDirectory = "Saves";
        public const string RawPreffix = "rawdata";

        public static string GetSaveName(string prefix, string scene)
        {
            return (Path.Combine(saveDirectory, prefix, scene)) + ".save"; // /Saves/Game/Scene
        }

        public static string GetFullPath(string prefix, string scene)
        {
            return Path.Combine(Application.persistentDataPath, saveDirectory, prefix, scene) + ".save";
        }

        public static string GetPrefix(string saveName)
        {
            string[] tab = saveName.Split('.');

            if (tab.Length == 0)
                return null;
            return tab[0];
        }

        public static string Save(object data, string saveName, string scene)
        {
            CheckValidity(saveName);
            string name = GetSaveName(saveName, scene);
            string existing = GetLastSave(saveName, scene);

            if (!String.IsNullOrEmpty(existing))
                File.Delete(existing);
            return SerializationManager.Save(name, data);
        }

        public static object Load(string prefix, string scene)
        {
            CheckValidity(prefix);
            string path = GetLastSave(prefix, scene);

            if (path != null)
                return SerializationManager.Load(GetLastSave(prefix, scene));
            return null;
        }

        private static void CheckValidity(string saveName)
        {
            string dir = Path.Combine(Path.Combine(Application.persistentDataPath, saveDirectory), saveName);

            if (!Directory.Exists(Path.Combine(Application.persistentDataPath, saveDirectory)))
                Directory.CreateDirectory(Path.Combine(Application.persistentDataPath, saveDirectory));
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
        }

        public static string GetLastSave(string prefix, string scene)
        {
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(Application.persistentDataPath, saveDirectory, prefix));
            FileInfo[] result = dir.GetFiles();
            FileInfo res;

            result = result.Where(f => f.Name.Contains(scene)).ToArray();
            res = result.OrderByDescending(c => c.LastWriteTime).FirstOrDefault();
            return (res == null ? null : res.FullName);
        }

        public static string[] GetAllSaves()
        {
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(Application.persistentDataPath, saveDirectory));
            DirectoryInfo[] files = dir.GetDirectories();
            List<string> result = new List<string>();

            foreach (DirectoryInfo d in files)
                result.Add(d.Name);
            return result.ToArray();
        }
    }
}
