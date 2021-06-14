using System;
using System.IO;
using UnityEngine;

namespace Assets.Scripts
{
    public static class SaveSystem
    {
        private static readonly string SAVE_FOLDER =  Application.persistentDataPath /* + "/Saves"*/;

        // IF ANDROID PLATFORM
        //private static readonly string SAVE_FOLDER = Application.persistentDataPath;

        public static void Save(string saveString)
        {
            File.WriteAllText(SAVE_FOLDER + "/save.txt", saveString);
        }

        public static string Load()
        {
            if(File.Exists(SAVE_FOLDER + "/save.txt"))
            {
                string saveString = File.ReadAllText(SAVE_FOLDER + "/save.txt");
                return saveString;
            }
            else
            {
                return null;
            }
        }

        public static SaveObject GetSaveObject()
        {
            string json = Load();
            if (json != null)
            {
                SaveObject saveObject = JsonUtility.FromJson<SaveObject>(json);

                return saveObject;
            }

            return new SaveObject();
        }
    }
}
