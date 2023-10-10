using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 50f;
    Rigidbody2D rb;
    public GameObject tombstone;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.up * speed;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ghost")
        {
            Instantiate(tombstone, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<movement>().score += 1;
            Camera.main.GetComponent<cameraScript>().Shake();
        }
        Destroy(gameObject);
    }
}
