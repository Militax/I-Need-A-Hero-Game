using System;
using System.IO;
using System.Linq;
using UnityEngine;

namespace SaveSystem
{
	class SaveDictionary
	{
        static string saveDirectory = "Saves";

        public static string GetSaveName(string prefix)
        {
            string creation = DateTime.Now.ToShortDateString().Replace("/", "-") + "_" + DateTime.Now.ToShortTimeString().Replace(":", "-");
            string namePath = prefix + "-" + creation + ".save";

            return (Path.Combine(saveDirectory, namePath));
        }

        public static string Save(object data, string saveName)
        {
            CheckValidity();
            string name = GetSaveName(saveName);
            string existing = GetLastSave(saveName);

            if (!String.IsNullOrEmpty(existing))
                File.Delete(existing);
            return SerializationManager.Save(name, data);
        }

        public static object Load(string saveName)
        {
            CheckValidity();
            string path = GetLastSave(saveName);

            if (path != null)
                return SerializationManager.Load(GetLastSave(saveName));
            return null;
        }

        private static void CheckValidity()
        {
            if (!Directory.Exists(Path.Combine(Application.persistentDataPath, saveDirectory)))
                Directory.CreateDirectory(Path.Combine(Application.persistentDataPath, saveDirectory));
        }

        public static string GetLastSave(string saveName)
        {
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(Application.persistentDataPath, saveDirectory));
            FileInfo[] result = dir.GetFiles();
            FileInfo res;

            result = result.Where(f => f.Name.Contains(saveName)).ToArray();
            res = result.OrderByDescending(c => c.LastWriteTime).FirstOrDefault();
            return (res == null ? null : res.FullName);
        }
    }
}
