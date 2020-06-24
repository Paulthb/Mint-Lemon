using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouilletteScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TouilletteLifeTime());
    }

    public IEnumerator TouilletteLifeTime()
    {
        yield return new WaitForSeconds(3.15f);

        Destroy(this.gameObject);
    }
}