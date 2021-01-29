using System;
using System.Collections;
using System.Collections.Generic;
using Helpers;
using Services;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts
{
    public class GameManager : MonoBehaviour
    {
        private  AudioSource deathSound;
        public GameObject gameOverCanvas;
        public GameObject sceneManager;
        public GameObject pauseCanvasOverlay;
        public GameObject pauseCanvas;

        private void Start()
        {
            deathSound = GetComponent<AudioSource>();
            Time.timeScale = 1;
            gameOverCanvas.SetActive(false);
            pauseCanvas.SetActive(true);
            pauseCanvasOverlay.SetActive(false);
        }

        public void GameOver()
        {
            deathSound.Play();
            gameOverCanvas.SetActive(true);
            pauseCanvas.SetActive(false);
            pauseCanvasOverlay.SetActive(false);
            int score = Score.score;
            StorageService.SetLevelHighScore(SceneManager.GetActiveScene().name, score);
            Time.timeScale = 0;
        }

        public void Restart()
        {
            SceneHelper sceneHelper = sceneManager.GetComponent<SceneHelper>();
            sceneHelper.ChangeToScene(SceneManager.GetActiveScene().name);
        }

        public void Pause()
        {
            Time.timeScale = 0;
            pauseCanvas.SetActive(false);
            pauseCanvasOverlay.SetActive(true);
            gameOverCanvas.SetActive(true);
        }

        public void Resume()
        {
            Time.timeScale = 1;
            pauseCanvas.SetActive(true);
            pauseCanvasOverlay.SetActive(false);
            gameOverCanvas.SetActive(false);
        }
    }
}