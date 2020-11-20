using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPipe : MonoBehaviour
{
    public GameObject pipe;
    public float height;

    private float time = 0;
    private float maxTime = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject newPipe = pipe;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.time >= maxTime) {
            Instantiate(
                this.pipe, 
                new Vector3(0,this.getRandomPosition(height), 0), 
                Quaternion.identity
            );
            this.time = 0;
        }
        this.time += Time.deltaTime;
    }

    float getRandomPosition(float height)
    {
        return Random.Range(-height, height);
    }
}
