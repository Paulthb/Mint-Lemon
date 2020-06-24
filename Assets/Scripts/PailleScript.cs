using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PailleScript : MonoBehaviour
{
    [SerializeField]
    private GameObject holePrefab = null;

    private bool holeDropped = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PailleAnimation());
    }

    public IEnumerator PailleAnimation()
    {
        yield return new WaitForSeconds(1f);
        if (!holeDropped)
        {
            Instantiate(holePrefab, transform.position, Quaternion.identity, PlatFormScript.Instance.transform);
            holeDropped = true;
        }
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
