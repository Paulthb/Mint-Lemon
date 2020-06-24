using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField]
    private List<AcidSpawner> spawnerList = null;

    [SerializeField]
    private List<Transform> acidDropPosList = null;

    [SerializeField]
    private List<Transform> holesPosList = null;

    [SerializeField]
    private GameObject paillePrefab = null;

    [SerializeField]
    private GameObject touillettePrefab = null;

    [SerializeField]
    private PlatFormScript platform = null;

    #region Singleton Pattern
    private static EventManager _instance;

    public static EventManager Instance { get { return _instance; } }
    #endregion

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);

        else
            _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(EventTimer());
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //    ActivateTouillette();
    }


    public IEnumerator EventTimer()
    {
        yield return new WaitForSeconds(3);
        AcidDrop();

        yield return new WaitForSeconds(3);
        HoleDrop();

        yield return new WaitForSeconds(3);
        LaunchRandomEvent(1, 2);

        yield return new WaitForSeconds(3);
        LaunchRandomEvent(1, 2);

        yield return new WaitForSeconds(3);
        HoleDrop();

        yield return new WaitForSeconds(3);
        ActivateTouillette();

        yield return new WaitForSeconds(3);
        LaunchRandomEvent(1, 3);

        yield return new WaitForSeconds(3);
        LaunchRandomEvent(1, 3);

        yield return new WaitForSeconds(3);
        HoleDrop();

        yield return new WaitForSeconds(3);
        LaunchRandomEvent(1, 3);

        yield return new WaitForSeconds(3);
        LaunchRandomEvent(1, 3); ;

        yield return new WaitForSeconds(3);
        HoleDrop();

        yield return new WaitForSeconds(3);
        LaunchRandomEvent(1, 3);

        yield return new WaitForSeconds(3);
        LaunchRandomEvent(1, 3);

        yield return new WaitForSeconds(3);
        LaunchRandomEvent(1, 3);

        yield return new WaitForSeconds(3);
        HoleDrop();

        yield return new WaitForSeconds(3);
        LaunchRandomEvent(1, 3);

        yield return new WaitForSeconds(3);
        LaunchRandomEvent(1, 3);

        yield return new WaitForSeconds(3);
        LaunchRandomEvent(1, 3);

        yield return new WaitForSeconds(3);
        HoleDrop();

        yield return new WaitForSeconds(3);
        LaunchRandomEvent(1, 3);

        yield return new WaitForSeconds(3);
        LaunchRandomEvent(1, 3);

        yield return new WaitForSeconds(3);
        HoleDrop();
    }


    public void LaunchRandomEvent(int minEventId, int maxEventId)
    {
        int randId = Random.Range(minEventId, maxEventId);

        switch(randId)
        {
            case 1:
                AcidDrop();
                break;
            case 2:
                ActivateTouillette();
                break;
            case 3:
                HoleDrop();
                break;
            default:
                AcidDrop();
                break;
        }
    }

    public void AcidDrop()
    {
        int randSpawnerId = Random.Range(0, spawnerList.Count - 1);
        int randAcidPosId = Random.Range(0, acidDropPosList.Count - 1);

        //Debug.Log(randSpawnerId);
        //Debug.Log(randAcidPosId);

        spawnerList[randSpawnerId].SpawnAcid(acidDropPosList[randAcidPosId]);
    }

    public void HoleDrop()
    {
        int randHolesPosId = Random.Range(0, holesPosList.Count - 1);
        Instantiate(paillePrefab, holesPosList[randHolesPosId].position, Quaternion.identity);
    }

    public void ActivateTouillette()
    {
        Instantiate(touillettePrefab);
        StartCoroutine(platform.TouilletteActivate(false));
    }
}
