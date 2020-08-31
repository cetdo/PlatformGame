using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    private Animator animator;
    private Rigidbody2D rigid;

    public bool isJuming;
    public bool doubleJump;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {

        if(SingleJoystick.Instance)
		{
            float horizontal = SingleJoystick.Instance.GetInputDirection().x;
            Vector3 movement = new Vector3(horizontal, 0f, 0f);
			transform.position += movement * Time.deltaTime * speed;
			//vertical = SingleJoystick.Instance.GetInputDirection().y;
		}


        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        //transform.position += movement * Time.deltaTime * speed;

        if (Input.GetAxis("Horizontal") > 0f)
        {
            animator.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        if (Input.GetAxis("Horizontal") < 0f)
        {
            animator.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        if (Input.GetAxis("Horizontal") == 0)
        {
            animator.SetBool("walk", false);
        }
        

    }

    void Jump()
    {
        if (Input.GetButton("Jump"))
        {
            if (!isJuming)
            {
                animator.SetBool("jump", true);
                rigid.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                doubleJump = true;
            }
            else
            {
                if (doubleJump)
                {
                    Debug.Log("Double jump");
                    rigid.AddForce(new Vector2(0f, jumpForce * 1.5f), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }

        }

        if (SingleJoystick.Instance)
        {
            if (!isJuming)
            {
                animator.SetBool("jump", true);
                rigid.AddForce(new Vector2(0f, (jumpForce*SingleJoystick.Instance.GetInputDirection().y)), ForceMode2D.Impulse);
                doubleJump = true;
            }
            else
            {
                if (doubleJump)
                {
                    Debug.Log("Double jump");
                    rigid.AddForce(new Vector2(0f, (jumpForce*SingleJoystick.Instance.GetInputDirection().y) * 1.5f), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJuming = false;
            animator.SetBool("jump", false);
        }

        if (collision.gameObject.tag == "Spike")
        {
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }

        
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJuming = true;
        }
    }

}
