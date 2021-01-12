using UnityEngine;

public class StorageService : MonoBehaviour
{
    private const string HighScoreText = "_HighScore";
    private const string LevelDifficultyText = "Game_Difficulty";

    public static bool GetSettingsField(string field)
    {
        return PlayerPrefs.GetInt(field) == 1;    
    }

    public void SetSettingsField(string fieldName, bool value)
    {
        PlayerPrefs.SetInt(fieldName, value ? 1 : 0);
        PlayerPrefs.Save();
    }
    
    public static int GetLevelHighScore(string levelName)
    {
        return PlayerPrefs.GetInt($"{levelName}{HighScoreText}");
    }

    public static void SetLevelHighScore(string levelName, int score)
    {
        var currentHighScore = PlayerPrefs.GetInt($"{levelName}{HighScoreText}");
        if (currentHighScore < score) {
            PlayerPrefs.SetInt($"{levelName}{HighScoreText}", score);
        }
    }

    public static int GetLevelDifficulty()
    {
        return PlayerPrefs.GetInt(LevelDifficultyText) == 0
            ? 1
            : PlayerPrefs.GetInt(LevelDifficultyText);
    }
    
    public static void SetLevelDifficulty(int value)
    {
        PlayerPrefs.SetInt(LevelDifficultyText, value);
    }
}