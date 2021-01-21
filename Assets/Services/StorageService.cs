using UnityEngine;

namespace Services
{
    public class StorageService : MonoBehaviour
    {
        private const string HighScoreKey = "_HighScore_Difficulty_";
        private const string LevelDifficultyKey = "Game_Difficulty";

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
            return PlayerPrefs.GetInt($"{levelName}{HighScoreKey}{GetLevelDifficulty().ToString()}");
        }

        public static void SetLevelHighScore(string levelName, int score)
        {
            var currentHighScore = PlayerPrefs.GetInt($"{levelName}{HighScoreKey}{GetLevelDifficulty().ToString()}");
            if (currentHighScore < score) {
                PlayerPrefs.SetInt($"{levelName}{HighScoreKey}{GetLevelDifficulty().ToString()}", score);
            }
        }

        public static int GetLevelDifficulty()
        {
            return PlayerPrefs.GetInt(LevelDifficultyKey);
        }

        public static void SetLevelDifficulty(int value)
        {
            PlayerPrefs.SetInt(LevelDifficultyKey, value);
        }
    }
}