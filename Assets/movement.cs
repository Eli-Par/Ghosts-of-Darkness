using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class movement : MonoBehaviour
{
    public float speed;

    public Rigidbody2D rb;

    public float rotationOffset = -90f;

    Vector2 moveDir;

    public GameObject bullet;

    public GameObject bP1;
    public GameObject bP2;

    public float shootDelay = 0.5f;

    public TextMeshProUGUI text;

    public Slider slider;

    public GameObject sFill;

    public GameObject restart;

    float lastShotTime = 0;

    public int score = 0;

    public int health = 3;

    public GameObject shotSound;

    public GameObject hit;

    public GameObject spawner;

    float isShooting = 0;
    public float shootTime = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = score.ToString();
        slider.value = health;
        if (health == 0)
        {
            sFill.SetActive(false);
            gameObject.SetActive(false);
            restart.SetActive(true);
            spawner.SetActive(false);
        }

        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.y = Input.GetAxisRaw("Vertical");
        moveDir.Normalize();
        rb.velocity = moveDir * speed;

        Vector2 cPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = cPoint - rb.position;
        float rotation = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = rotation + rotationOffset;

        isShooting -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
        {
            isShooting = shootTime;
        }

        if(isShooting > 0 && lastShotTime < Time.time)
        {
            lastShotTime = Time.time + shootDelay;
            Instantiate(bullet, bP1.transform.position, bP1.transform.rotation);
            Instantiate(bullet, bP2.transform.position, bP1.transform.rotation);
            Instantiate(shotSound, transform.position, Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ghost")
        {
            health--;
            Destroy(collision.gameObject);
            Instantiate(hit, transform.position, Quaternion.identity);
            Camera.main.GetComponent<cameraScript>().Hit();
        }
    }
}
