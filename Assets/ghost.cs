using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost : MonoBehaviour
{
    GameObject player;
    public float speed;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            Vector2 dir = player.transform.position - transform.position;
            dir.Normalize();

            transform.position = transform.position + new Vector3(dir.x, dir.y, 0) * speed * Time.deltaTime;
        }
        
    }
}
