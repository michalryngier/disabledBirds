using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class StorageService : MonoBehaviour
{
    private const string STORAGE_FILE_PATH = "/Saved Games/DisabledBirds/";
    private const string STORAGE_FILE_NAME = "gameData.xml";

    private void Start()
    {
        CreateDirectoryIfNotExists();
        if (CheckStorageFileExists() == false) {
            GenerateXMLSchemaAndSaveFile();
        }
    }

    public static bool GetSettingsField(string field)
    {
        StorageSettings settings = GetSettings();
        switch (field) {
            case "Music":
                return settings.Music;
            case "Sound":
                return settings.Sound;
            case "Shaders":
                return settings.Shaders;
            default: return true;
        }
    }

    public void SetSettingsField(string fieldName, bool value)
    {
        var storage = GetStorage();
        switch (fieldName) {
            case "Music":
                storage.Settings.Music = value;
                break;
            case "Sound":
                storage.Settings.Sound = value;
                break;
            case "Shaders":
                storage.Settings.Shaders = value;
                break;
        }
        GenerateXMLSchemaAndSaveFile(storage);
    }

    public static void SetLevelHighScore(string levelName, int score)
    {
        var storage = GetStorage();
        if (GetLevelHighScore(levelName) != null) {
            if (GetLevelHighScore(levelName) < score) {
                storage.Levels.Find(level => level.LevelName == levelName).HighScore = score;
                GenerateXMLSchemaAndSaveFile(storage);
            }
        }
        else {
            StorageLevelData newLevelData = new StorageLevelData {HighScore = score, LevelName = levelName};
            storage.Levels.Add(newLevelData);
            GenerateXMLSchemaAndSaveFile(storage);
        }
    }

    public static int? GetLevelHighScore(string levelName)
    {
        StorageLevelData levelData = GetLevel(levelName);
        return levelData?.HighScore;
    }
    
    [CanBeNull]
    private static StorageLevelData GetLevel(string levelName)
    {
        List<StorageLevelData> levels = GetStorage().Levels;
        return levels.Find(level => level.LevelName == levelName);
    }
    
    private static StorageSettings GetSettings()
    {
        return GetStorage().Settings;
    }

    private static void CreateDirectoryIfNotExists()
    {
        var directory = $"{GetUserProfilePath()}{STORAGE_FILE_PATH}";
        if (Directory.Exists(directory) == false) {
            Directory.CreateDirectory(directory);
        }
    }

    private static string GetUserProfilePath()
    {
        return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
    }

    [CanBeNull]
    private static Storage GetStorage()
    {
        if (CheckStorageFileExists() != true) return new Storage();
        XmlSerializer serializer = new XmlSerializer(typeof(Storage));
        using (Stream reader = new FileStream(GetStorageFileFullPath(), FileMode.Open))
        {
            return (Storage)serializer.Deserialize(reader);
        }

    }
    private static void GenerateXMLSchemaAndSaveFile(Storage storageSchema = null)
    {
        if (storageSchema == null) {
            storageSchema = new Storage();
        }
        try
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(storageSchema.GetType());
            using (MemoryStream stream = new MemoryStream())
            {
                serializer.Serialize(stream, storageSchema);
                stream.Position = 0;
                xmlDocument.Load(stream);
                xmlDocument.Save(GetStorageFileFullPath());
            }
        }
        catch (Exception ex)
        {
            Debug.Log(ex);
        }
    }

    private static bool CheckStorageFileExists()
    {
        return File.Exists(GetStorageFileFullPath());
    }

    private static string GetStorageFileFullPath()
    {
        return GetUserProfilePath() + STORAGE_FILE_PATH + STORAGE_FILE_NAME;
    }
}