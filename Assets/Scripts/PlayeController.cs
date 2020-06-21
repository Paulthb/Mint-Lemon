using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayeController : MonoBehaviour
{
    private Rigidbody2D rb;

    //private bool moving = false;

    [SerializeField]
    private string horizontalAxe = "";
    [SerializeField]
    private string verticalAxe = "";

    public float speed = 5;

    private bool playerHasMove = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis(horizontalAxe);
        float moveVertical = Input.GetAxis(verticalAxe);
        Vector2 movement = new Vector3(moveHorizontal, moveVertical);

        //au début de la game
        if (moveHorizontal >= 0.8f || moveHorizontal <= -0.8f || moveVertical >= 0.8f || moveVertical <= -0.8f)
        {
            if(playerHasMove == false)
            {
                GameManager.Instance.PlayerHasMove();
                playerHasMove = true;
            }

            rb.velocity = new Vector2(movement.x * speed, movement.y * speed);
        }

        Debug.Log("velocity : " + rb.velocity);
        Debug.Log("x : " + movement.x + " y : " + movement.y);
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = rb.velocity * 0.9f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //si on sot du citron, Game Over
        if(collision.gameObject.tag == "Platform")
        {
            GameManager.Instance.GameOver();
        }
    }
}
