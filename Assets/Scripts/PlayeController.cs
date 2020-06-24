using System;
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
    private GameObject trailNormal = null;
    [SerializeField]
    private GameObject trailHightSpeed = null;

    [SerializeField]
    private Animator mrMintAnimator = null;

    [NonSerialized]
    public bool isPlayerAlive = true;

    public float speed = 5;
    float baseSpeed;

    private bool isAccelerateted = false;
    private float accelElapseTime = 0;

    private bool isJumping = false;

    private bool playerHasMove = false;
    private Rigidbody2D rb = null;


    /// <summary>
    /// ///////////////////////////
    /// </summary>
    public float m_moveForce = 60f;
    public float m_maxSpeed = 10f;




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

        if ((moveHorizontal >= 0.8f || moveHorizontal <= -0.8f || moveVertical >= 0.8f || moveVertical <= -0.8f) && isPlayerAlive )
        {
            //au début de la game
            if(playerHasMove == false)
            {
                GameManager.Instance.PlayerHasMove();
                playerHasMove = true;
                mrMintAnimator.SetBool("IsMoving", true);
            }

            //rotation du sprite
            if (moveHorizontal > 0)
                mrMint.localRotation = Quaternion.Euler(0, 0, 0);
            if (moveHorizontal < 0)
                mrMint.localRotation = Quaternion.Euler(0, 180, 0);

            rb.velocity = new Vector2(movement.x * speed, movement.y * speed);
        }

        if (Input.GetButton("Jump") && !isJumping)
            StartCoroutine(PlayerJump());
    }

    //private void FixedUpdate()
    //{
    //    float hAx = Input.GetAxis(horizontalAxe);
    //    float vAx = Input.GetAxis(horizontalAxe);

    //    ////Use the two store floats to create a new Vector2 variable movement.
    //    Vector2 movement = new Vector2(hAx, vAx);

    //    rb.AddForce(movement * m_moveForce);

    //    if (Mathf.Abs(rb.velocity.x) > m_maxSpeed)
    //        rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * m_maxSpeed, rb.velocity.y);

    //    if (Mathf.Abs(rb.velocity.y) > m_maxSpeed)
    //        rb.velocity = new Vector2(rb.velocity.x, Mathf.Sign(rb.velocity.y) * m_maxSpeed);
    //}

    private void OnTriggerExit2D(Collider2D collision)
    {
        //si on sot du citron, Game Over
        if(collision.gameObject.tag == "Platform" && !isJumping)
            PlayerDeath();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Acid" && !isJumping)
        {
            speed = baseSpeed;
            if (isAccelerateted)
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

    public IEnumerator PlayerJump()
    {
        mrMintAnimator.SetBool("IsJumping", true);
        isJumping = true;
        yield return new WaitForSeconds(1f);
        mrMintAnimator.SetBool("IsJumping", false);
        isJumping = false;
    }

    public void PlayerDeath()
    {
        isPlayerAlive = false;
        mrMintAnimator.SetBool("IsDead", true);
        rb.velocity = Vector3.zero;

        GameManager.Instance.GameOver();
    }
}
