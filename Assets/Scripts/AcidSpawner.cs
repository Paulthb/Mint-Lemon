using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject platform;

    [SerializeField]
    private List<AcidDrop> AcidDropList = null;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnAcid(Transform destination)
    {
        int randAcidId = Random.Range(0, AcidDropList.Count);

        GameObject acidObject = Instantiate(AcidDropList[randAcidId].gameObject, transform.position, Quaternion.identity, platform.transform);
        StartCoroutine(EnemyPlacement(destination, acidObject.transform));
    }

    public IEnumerator EnemyPlacement(Transform destination, Transform acidTransform)
    {
        float elapsedTime = 0;
        float waitTime = 0.5f;

        Vector3 basePos = acidTransform.position;

        while (elapsedTime < waitTime)
        {
            acidTransform.position = Vector3.Lerp(basePos, destination.position, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }
        acidTransform.position = destination.position;

        acidTransform.GetComponent<AcidDrop>().AcidDropped();
    }
}
