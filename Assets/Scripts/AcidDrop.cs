using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidDrop : MonoBehaviour
{
    private SpriteRenderer acidDroppedSprite = null;

    private CircleCollider2D col = null;


    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<CircleCollider2D>();
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
    }
}
