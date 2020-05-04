using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;

namespace SaveSystem
{
    public class SerializationManager
    {
        private static string ConcatenatePath(string fileName)
        {
            return Path.Combine(Application.persistentDataPath, fileName);
        }

        public static string Save(string saveName, object saveData) // saveName SaveDirectories/FileName => e.g Saves/sample.save
        {
            string absolutePath = ConcatenatePath(saveName);

            Debug.Log(absolutePath);
            BinaryFormatter formatter = GetBinaryFormatter();
            FileStream file = File.Create(absolutePath);

            formatter.Serialize(file, saveData);
            file.Close();
            return absolutePath;
        }

        public static object Load(string path)
        {
            if (!File.Exists(path))
                return null;

            BinaryFormatter formatter = GetBinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);

            try
            {
                object save = formatter.Deserialize(file);
                file.Close();
                return save;
            }
            catch
            {
                Debug.LogErrorFormat("Failed to load flie at {0}", path);
                file.Close();
                return null;
            }
        }

        public static BinaryFormatter GetBinaryFormatter()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            SurrogateSelector selector = new SurrogateSelector();
            Vector3SerializationSurrogate vector3Surrogate = new Vector3SerializationSurrogate();
            QuaternionSurrogate quaternionSurrogate = new QuaternionSurrogate();

            selector.AddSurrogate(typeof(Vector3), new StreamingContext(StreamingContextStates.All), vector3Surrogate);
            selector.AddSurrogate(typeof(Quaternion), new StreamingContext(StreamingContextStates.All), quaternionSurrogate);
            formatter.SurrogateSelector = selector;
            return formatter;
        }
    }
}
