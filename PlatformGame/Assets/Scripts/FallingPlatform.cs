using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{

    public float fallingTime;

    private TargetJoint2D targuet;
    private BoxCollider2D boxCollider;


    // Start is called before the first frame update
    void Start()
    {
        targuet = GetComponent<TargetJoint2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("Falling", fallingTime);
        }

        if (collision.gameObject.layer == 9)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 9)
        {
            Destroy(gameObject);
        }
    }

    void Falling()
    {
        targuet.enabled = false;
        boxCollider.isTrigger = true;
    }
}
