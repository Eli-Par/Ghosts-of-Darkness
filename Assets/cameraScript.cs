using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public GameObject player;

    public float dist;
    public float scale;
    public float duration;

    float lastTime = 0;

    [Space]
    public float Ddist;
    public float Dscale;
    public float Dduration;

    float DlastTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xOffset = 0;
        float yOffset = 0;
        if (Time.time < lastTime)
        {
            xOffset = dist * Mathf.PerlinNoise(Time.time * scale, 0.0f);
            yOffset = dist * Mathf.PerlinNoise(Time.time * scale, 100.0f);
        }
        if (Time.time < DlastTime)
        {
            xOffset = Ddist * Mathf.PerlinNoise(Time.time * Dscale, 0.0f);
            yOffset = Ddist * Mathf.PerlinNoise(Time.time * Dscale, 100.0f);
        }
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z) + new Vector3(xOffset, yOffset, 0);
    }

    public void Shake()
    {
        lastTime = Time.time + duration;
    }

    public void Hit()
    {
        lastTime = Time.time + duration;
    }
}
