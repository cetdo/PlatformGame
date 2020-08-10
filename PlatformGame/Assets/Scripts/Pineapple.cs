using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pineapple : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private CapsuleCollider2D capCollider;

    public int score = 0;


    public GameObject collected;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        capCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            spriteRenderer.enabled = false;
            capCollider.enabled = false;
            collected.SetActive(true);

            GameController.instance.totalScore += score;
            GameController.instance.UpdateScoreText();

            Destroy(gameObject, 0.4f);
        }
    }
}
