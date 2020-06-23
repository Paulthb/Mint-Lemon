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
    float baseSpeed;

    private bool isAccelerateted = false;
    private float accelElapseTime = 0;

    private bool playerHasMove = false;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        baseSpeed = speed;
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
            speed = baseSpeed;
            if(isAccelerateted)
                accelElapseTime = 0;
            else
                StartCoroutine(AcidEffect());
        }
    }

    private IEnumerator AcidEffect()
    {
        isAccelerateted = true;
        float waitTime = 1f;

        trailNormal.SetActive(false);
        trailHightSpeed.SetActive(true);

        speed = speed + 2;
        float newSpeed = speed;

        Debug.Log(baseSpeed);

        while (accelElapseTime < waitTime)
        {
            speed = Mathf.Lerp(newSpeed, baseSpeed, (accelElapseTime / waitTime));
            accelElapseTime += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        accelElapseTime = 0;
        speed = baseSpeed;

        trailNormal.SetActive(true);
        trailHightSpeed.SetActive(false);
        isAccelerateted = false;
    }
}
