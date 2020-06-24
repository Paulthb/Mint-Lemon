using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidDrop : MonoBehaviour
{
    public Sprite acidDroppedSprite = null;

    private BoxCollider2D col = null;
    private SpriteRenderer sprite = null;

    public float acidLifeTime = 5;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
     * quand l'object atteint sa position
     * on active son collider et on change son sprite
     */
    public void AcidDropped()
    {
        col.enabled = true;
        sprite.sprite = acidDroppedSprite;

        transform.localScale = new Vector3(0.26f, 0.18f, 0);
        StartCoroutine(AcidLifeTime());
    }

    public IEnumerator AcidLifeTime()
    {
        yield return new WaitForSeconds(acidLifeTime);
        Destroy(this);
    }
}
