using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Services;
using UnityEngine.UI;

namespace Scripts
{
    public class SetVisibleHighScore : MonoBehaviour
    {
        public string levelName;

        private Text textComponent;

        // Start is called before the first frame update
        void Start()
        {
            textComponent = GetComponent<UnityEngine.UI.Text>();
        }

        void Update()
        {
            var score = StorageService.GetLevelHighScore(levelName);
            textComponent.text = score.ToString();
        }
    }
}
