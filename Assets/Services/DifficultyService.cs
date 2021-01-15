using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Services
{
    public class DifficultyService : MonoBehaviour
    {
        private const int Normal = 0;
        private const int Hard = 1;
        private string NormalText = "Difficulty: Normal";
        private string HardText = "Difficulty: Hard";
        private Text difficultyButtonTextComponent;
        public GameObject difficultyButtonText;

        // Start is called before the first frame update
        void Start()
        {
            difficultyButtonTextComponent = difficultyButtonText.GetComponent<Text>();
            changeDifficultyToNormal();
        }

        // Update is called once per frame
        void Update()
        {
            if (getDifficulty() == Hard && difficultyButtonTextComponent.text == NormalText) {
                changeDifficultyToHard();
            }
            else if (getDifficulty() == Normal && difficultyButtonTextComponent.text == HardText) {
                changeDifficultyToNormal();
            }
        }

        private static int getDifficulty()
        {
            return StorageService.GetLevelDifficulty();
        }

        public void switchDifficulty()
        {
            var difficulty = getDifficulty() == 0 ? Hard : Normal;
            difficultyButtonTextComponent.text = difficulty == Hard ? HardText : NormalText;
            StorageService.SetLevelDifficulty(difficulty);
        }

        public void changeDifficultyToNormal()
        {
            StorageService.SetLevelDifficulty(Normal);
            difficultyButtonTextComponent.text = NormalText;
        }

        public void changeDifficultyToHard()
        {
            StorageService.SetLevelDifficulty(Hard);
            difficultyButtonTextComponent.text = HardText;
        }

        public static float getDifficultySpeedMultiplier()
        {
            var difficulty = getDifficulty();
            var multiplier = 0.6f;
            return difficulty == 0 ? 1f : difficulty * multiplier;
        }

        public static float getDifficultyVelocityMultiplier()
        {
            var difficulty = getDifficulty();
            var multiplier = 0.7f;
            return difficulty == 0 ? 1f : difficulty * multiplier;
        }
    }
}
