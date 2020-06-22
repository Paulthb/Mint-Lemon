using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayeController : MonoBehaviour
{
    [SerializeField]
    private string horizontalAxe = "";
    [SerializeField]
    private string verticalAxe = "";

    [SerializeField]
    private Transform mrMint = null;

    [SerializeField]
    private GameObject trailNormal;
    [SerializeField]
    private GameObject trailHightSpeed;


    public float speed = 5;

    private bool playerHasMove = false;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis(horizontalAxe);
        float moveVertical = Input.GetAxis(verticalAxe);
        Vector2 movement = new Vector3(moveHorizontal, moveVertical);

        if (moveHorizontal >= 0.8f || moveHorizontal <= -0.8f || moveVertical >= 0.8f || moveVertical <= -0.8f)
        {
            //au début de la game
            if(playerHasMove == false)
            {
                GameManager.Instance.PlayerHasMove();
                playerHasMove = true;
            }

            //rotation du sprite
            if (moveHorizontal > 0)
                mrMint.localRotation = Quaternion.Euler(0, 0, 0);
            if (moveHorizontal < 0)
                mrMint.localRotation = Quaternion.Euler(0, 180, 0);

            rb.velocity = new Vector2(movement.x * speed, movement.y * speed);
        }

        //Debug.Log("velocity : " + rb.velocity);
        //Debug.Log("x : " + movement.x + " y : " + movement.y);
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

        if (collision.gameObject.tag == "Acid")
        {
            StopCoroutine(AcidEffect());
            StartCoroutine(AcidEffect());
        }
    }

    private IEnumerator AcidEffect()
    {
        float elapsedTime = 0;
        float waitTime = 1f;

        trailNormal.SetActive(false);
        trailHightSpeed.SetActive(true);

        float baseSpeed = speed;
        speed = speed + 2;
        float newSpeed = speed;

        while (elapsedTime < waitTime)
        {
            speed = Mathf.Lerp(newSpeed, baseSpeed, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        speed = baseSpeed;
        trailNormal.SetActive(true);
        trailHightSpeed.SetActive(false);
    }
}
