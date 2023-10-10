using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scleaner : MonoBehaviour
{
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("delete", time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void delete()
    {
        Destroy(gameObject);
    }
}
