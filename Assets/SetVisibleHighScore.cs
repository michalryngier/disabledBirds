using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVisibleHighScore : MonoBehaviour
{
    public string levelName;
    // Start is called before the first frame update
    void Start()
    {
        var score = StorageService.GetLevelHighScore(levelName);
        GetComponent<UnityEngine.UI.Text>().text = score.ToString();
    }
}
