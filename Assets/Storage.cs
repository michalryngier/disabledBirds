using System;
using System.Collections.Generic;
using UnityEngine.XR.WSA.Input;

public class Storage
{
    public StorageSettings Settings;
    public List<StorageLevelData> Levels = new List<StorageLevelData>();

    public Storage()
    {
        Settings = new StorageSettings();
    }
}

public class StorageLevelData
{
    private string LevelNameValue;
    public string LevelName
    {
        get => LevelNameValue;
        set => LevelNameValue = value;
    }

    private int HighScoreValue;
    public int HighScore
    {
        get => HighScoreValue;
        set => HighScoreValue = value;
    }
}

public class StorageSettings
{
    public StorageSettings()
    {
        Sound = true;
        Music = true;
        Shaders = true;
    }

    private bool SoundValue;
    public bool Sound {
        get => SoundValue;
        set => SoundValue = value;
    }
    
    private bool MusicValue;
    public bool Music {
        get => MusicValue;
        set => MusicValue = value;
    }
    
    private bool ShadersValue;
    public bool Shaders {
        get => ShadersValue;
        set => ShadersValue = value;
    }
}
