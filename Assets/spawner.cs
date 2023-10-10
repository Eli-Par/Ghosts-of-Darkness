using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public float spawningSpeedValue;
    public GameObject ghost;

    public float topValue;
    public float horValue;

    public float startTime = 5f;
    public float minTime = 2f;

    public float changeTime = 30f;

    float spawnSpeed;

    float nextSpawnTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnSpeed = Mathf.Clamp(-((startTime - minTime)/changeTime) * Time.time + startTime, minTime, startTime);
        Debug.Log(spawnSpeed);

        int r = Random.Range(0, 4);

        if(Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + spawnSpeed;
            if (r == 0)
            {
                Instantiate(ghost, new Vector3(Random.Range(-horValue, horValue), topValue, 0), Quaternion.identity);
            }
            if (r == 1)
            {
                Instantiate(ghost, new Vector3(Random.Range(-horValue, horValue), -topValue, 0), Quaternion.identity);
            }

            if (r == 2)
            {
                Instantiate(ghost, new Vector3(horValue, Random.Range(-topValue, topValue), 0), Quaternion.identity);
            }
            if (r == 3)
            {
                Instantiate(ghost, new Vector3(-horValue, Random.Range(-topValue, topValue), 0), Quaternion.identity);
            }
        }
    }
}
