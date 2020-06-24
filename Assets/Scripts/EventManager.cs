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
        yield return new WaitForSeconds(5);
        AcidDrop();

        yield return new WaitForSeconds(10);


        yield return new WaitForSeconds(15);


        yield return new WaitForSeconds(20);


        yield return new WaitForSeconds(25);


        yield return new WaitForSeconds(30);


        yield return new WaitForSeconds(35);


        yield return new WaitForSeconds(40);


        yield return new WaitForSeconds(45);


        yield return new WaitForSeconds(50);


        yield return new WaitForSeconds(55);


        yield return new WaitForSeconds(60);


        yield return new WaitForSeconds(65);


        yield return new WaitForSeconds(70);


        yield return new WaitForSeconds(80);


        yield return new WaitForSeconds(85);


        yield return new WaitForSeconds(90);


        yield return new WaitForSeconds(95);


        yield return new WaitForSeconds(100);


        yield return new WaitForSeconds(105);


        yield return new WaitForSeconds(110);


        yield return new WaitForSeconds(115);


        yield return new WaitForSeconds(120);
    }


    public void LaunchRandomEvent(int maxEventId)
    {
        int randId = Random.Range(1, maxEventId);

        switch(maxEventId)
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
